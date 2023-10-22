using api.DAL.Context;
using api.DAL.Interfaces.Common;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.AccessControl;
using api.DAL.Entities.Common;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using api.Shared.Extensions;

namespace api.DAL.Repositories.Common {
    public class PartialUpdateHelper : IPartialUpdateHelper {

        private readonly AppDbContext _db;

        public PartialUpdateHelper(AppDbContext db) {
            _db = db;
        }
        private Type GetNullableType(Type type) {
            // Use Nullable.GetUnderlyingType() to remove the Nullable<T> wrapper if type is already nullable.
            type = Nullable.GetUnderlyingType(type) ?? type; // avoid type becoming null
            if (type.IsValueType)
                return typeof(Nullable<>).MakeGenericType(type);
            else
                return type;
        }

        public T PartialUpdate<T>(dynamic modifiableEntity) where T : class {
            var idProp = modifiableEntity.GetType().GetProperty("Id");
            if (idProp == null) { 
                throw new KeyNotFoundException($"Id not found in entity: {nameof(modifiableEntity)}");
            }
            var id = idProp.GetValue(modifiableEntity);
            var dbEntity = _db.Set<T>().Find(id);
            if (dbEntity == null) {
                throw new NullReferenceException("Nem találtunk recordot az alábbi ID-val -> nincs UPDATE");
            }
            var dbEntityType = typeof(T);
            var modifiableType = modifiableEntity.GetType();
            //Le kérjük a BO tulajdonságait
            var props = modifiableType.GetProperties();
            foreach (var prop in props) {
                if (dbEntityType.GetProperty(prop.Name) == null) {
                    continue;
                }

                var dbValue = dbEntityType.GetProperty(prop.Name).GetValue(dbEntity);
                var updatedValue = prop.GetValue(modifiableEntity);
                if(updatedValue != null) {
                    if (updatedValue.GetType() == typeof(long) && (long)updatedValue == -1) {
                        dbEntityType.GetProperty(prop.Name).SetValue(dbEntity, null);

                    }
                }
               
                // megnézzük van e változás a DB-ben lévővel!
                if (updatedValue != null && !updatedValue.Equals(dbValue)) {


                    // Beállítjuk az új értéket!
                    dbEntityType.GetProperty(prop.Name).SetValue(dbEntity, updatedValue);
                }
            }
            var propVersionNumber = dbEntityType.GetProperty(nameof(BaseEntity.VersionNumber));
            if (propVersionNumber == null) {
                throw new NullReferenceException("Nincs Version number!");
            }
            long prevVersionNumber = (long)propVersionNumber!.GetValue(dbEntity)!;

            // Növeljük a verzió számot!
            propVersionNumber.SetValue(dbEntity, prevVersionNumber + 1);

            _db.SaveChanges();
            return dbEntity;
        }

        public object PartialUpdate(Type entityType, object entity) {
            var m = GetType().GetMethods().Single(p =>
                         p.Name == "PartialUpdate" && p.ContainsGenericParameters);
            var k = m.MakeGenericMethod(entityType)
               .Invoke(this, new[] { entity });
            return k!;
        }
    }
}

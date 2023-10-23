using api.DAL.Context;
using api.DAL.Entities.Common;
using api.DAL.Interfaces;
using api.DAL.Interfaces.Common;
using ESZD.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace api.DAL.Repositories {
    public class DictionaryManagerRepository : IDictionaryManagerRepository {

        private readonly AppDbContext _db;
        private readonly IPartialUpdateHelper _partialUpdate;
        private object entityDbSet;

        public DictionaryManagerRepository(AppDbContext db, IPartialUpdateHelper partialUpdate) {
            _db = db;
            _partialUpdate = partialUpdate;
        }

        public async Task<List<BaseEntityDictionary>> GetAll() {

            return await GetQuearyableDbSet().Where(x => x.Active && !x.Clone).ToListAsync();
        }
        public async Task<List<BaseEntityDictionary>> GetAllByProject(int projectId) {

            return await GetQuearyableDbSet().Where(x => x.Active && !x.Clone && (x.ProjectId == projectId || x.ProjectId == null)).ToListAsync();
        }

        public async Task<BaseEntityDictionary> GetById(int Id) {
            return await GetQuearyableDbSet().FirstOrDefaultAsync(x => x.Id == Id);
        }


        private IQueryable<BaseEntityDictionary> GetQuearyableDbSet() {
            return (entityDbSet as IQueryable).Cast<BaseEntityDictionary>();
        }



        public async Task<BaseEntityDictionary> Insert(BaseEntityDictionary record) {
            var dbSetType = entityDbSet.GetType();
            var entityType = dbSetType.GenericTypeArguments[0];
            var addMethod = dbSetType.GetMethod("Add");

            var correctEntity = TypeHelper.ChangeType(typeof(BaseEntityDictionary), entityType, record);



            addMethod?.Invoke(entityDbSet, new[] { correctEntity });
            try {
                await _db.SaveChangesAsync();
                return correctEntity as BaseEntityDictionary;
            }
            catch (Exception ex) {
                throw new Exception("Unable to save! See inner exception!", ex);
            }
        }



        [Obsolete]
        public async Task<BaseEntityDictionary> Update(BaseEntityDictionary record) {
            throw new NotImplementedException();
        }

        public async Task<BaseEntityDictionary> Delete(int Id) {
            var entity = await GetById(Id);
            entity.Active = false;
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Type GetEntityType(string entityTypeName) {
            var entityType = _db.Model.GetEntityTypes().First(x => x.Name.EndsWith(entityTypeName));
            var dbSetPropInfo = _db.GetType().GetProperty(entityTypeName);
            entityDbSet = dbSetPropInfo.GetValue(_db);
            return entityType.ConstructorBinding.RuntimeType;
        }

        public T PartialUpdate<T>(dynamic entity) where T : class {
            throw new NotImplementedException();
        }

        public object PartialUpdate(Type entityType, dynamic entity) {
            return _partialUpdate.PartialUpdate(entityType, entity);
        }
    }
}

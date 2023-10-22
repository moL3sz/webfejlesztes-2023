namespace api.DAL.Interfaces.Common {
    public interface IPartialUpdateHelper {

        T PartialUpdate<T>(dynamic entity) where T: class;
        object PartialUpdate(Type entityType, dynamic entity);
    }
}

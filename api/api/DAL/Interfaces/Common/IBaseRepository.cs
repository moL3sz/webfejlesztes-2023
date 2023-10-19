using api.DAL.Entities.Common;

namespace api.DAL.Interfaces.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();

        T GetById(long Id);

        T Insert(T entity);

        T Update(T entity);

        T Delete(long id);

    }
}

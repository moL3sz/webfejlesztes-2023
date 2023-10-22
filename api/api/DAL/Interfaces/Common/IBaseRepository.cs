using api.DAL.Entities.Common;

namespace api.DAL.Interfaces.Common
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int Id);

        Task<T> Insert(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(int Id);

    }
}

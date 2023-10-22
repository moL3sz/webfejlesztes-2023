namespace api.BLL.Interfaces.Common {
    /// <summary>
    /// Alap CRUD műveletek
    /// </summary>
    /// <typeparam name="T">Compact típus</typeparam>
    /// <typeparam name="J">Részletes típus</typeparam>
    public interface IBaseService<T, J> {

        Task<List<T>> GetAll();

        Task<J> GetById(int Id);

        Task<J> Insert(J dto);

        Task<J> Update(object dto);

        Task<J> Delete(int id);
    }

    /// <summary>
    ///  Alap CRUD műveletek
    /// </summary>
    /// <typeparam name="T">DTO</typeparam>
    public interface IBaseService<T> {

        Task<List<T>> GetAll();

        Task<T> GetById(int Id);

        Task<T> Insert(T dto);

        Task<T> Update(object dto);

        Task<T> Delete(int id);
    }

}

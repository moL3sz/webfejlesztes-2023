using api.DAL.Entities;

namespace api.DAL.Interfaces {
    public interface IUserRepository {

        Task<List<User>> GetAll();
    }
}

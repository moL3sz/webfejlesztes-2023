using api.API.DTO.Auth;
using api.DAL.Entities;

namespace api.BLL.Interfaces {
    public interface IUserHelper {


        public UserPrinciple GetUserPrinciple();
        Task<User?> GetCurrentUser();
    }
}

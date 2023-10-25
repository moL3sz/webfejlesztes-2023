using api.API.DTO.User;

namespace api.BLL.Interfaces {
    public interface IUserService {

        public Task<UserFullDTO> GetUserById(string userId);
    }
}

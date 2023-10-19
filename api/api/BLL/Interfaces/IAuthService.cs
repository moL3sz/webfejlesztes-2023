using api.API.DTO.Auth;

namespace api.BLL.Interfaces {
    public interface IAuthService {

        Task<string> Login(LoginUserDTO userDTO);

        Task Register(RegisterUserDTO userDTO);

        Task<List<UserDTO>> GetUsers();

    }
}

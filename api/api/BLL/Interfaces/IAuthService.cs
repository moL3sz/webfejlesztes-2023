using api.API.DTO.Auth;
using System.Security.Claims;

namespace api.BLL.Interfaces {
    public interface IAuthService {

        Task<string> Login(LoginUserDTO userDTO);

        Task Register(RegisterUserDTO userDTO);

        Task<List<UserDTO>> GetUsers();

        Task<List<Claim>> GetUserClaims();

        string GenerateToken(IEnumerable<Claim> claims);

    }
}

using api.API.DTO.Auth;
using api.BLL.Interfaces;
using api.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace api.BLL.Helpers {
    public class UserHelper : IUserHelper {

        private readonly HttpContextAccessor _contextAccessor = new HttpContextAccessor();
        private readonly UserManager<User> _userManager;
        public UserHelper(UserManager<User> userManager) {
            _userManager = userManager;
        }

        public UserPrinciple GetUserPrinciple() {
            var userRaw = _contextAccessor.HttpContext!.User;

            var email = userRaw.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            var id = userRaw.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var name = userRaw.Claims.First(x => x.Type == ClaimTypes.Name).Value;
            var roles = userRaw.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);

            return new UserPrinciple { Email = email, Id = id, Name = name, Roles = roles };
        }
        public async Task<User?> GetCurrentUser() {
            var userPrinciple = _contextAccessor.HttpContext!.User;
            return await _userManager.GetUserAsync(userPrinciple);
        }
    }
}

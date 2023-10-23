using api.BLL.Interfaces;

namespace api.BLL.Services {
    public class JWTHandler : IJWTHandler {
        private readonly IAuthService _authService;

        public JWTHandler(IAuthService authService) {
            _authService = authService;
        }

        public async Task AddJWTToResponse(HttpResponse response) {
            var claims = await _authService.GetUserClaims();
            var token = _authService.GenerateToken(claims);
            response.Cookies.Append("AUTH_TOKEN", token, new CookieOptions {
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTime.Now.AddMinutes(30),
                Path = "/"
            });
        }
    }
}

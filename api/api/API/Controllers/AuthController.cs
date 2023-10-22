using api.API.Controllers.Common;
using api.API.DTO.Auth;
using api.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace api.API.Controllers {

    [Tags("Hitelesítő kontroller")]
    public class AuthController : BaseController {

        private readonly IAuthService _authService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService) : base(logger) {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO) {
            try {

                var token = await _authService.Login(userDTO);
                return Ok(token);
            }
            catch (Exception) {

                throw;
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDTO) {
            try {
                await _authService.Register(userDTO);
                return Ok();
            }
            catch (Exception) {

                throw;
            }
        }

        [HttpGet("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll() {
            try {
                var userDTOs =await _authService.GetUsers();
                return Ok(userDTOs);
            }
            catch (Exception e) {

                throw;
            }
        }
    }
}

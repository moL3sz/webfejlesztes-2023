using api.API.Controllers.Common;
using api.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers {
    [Tags("Felhasználó vezerlő")]
    [Authorize]
    public class UserController : BaseController {
        private readonly IUserService _service;
        public UserController(ILogger<UserController> logger, IUserService service) : base(logger) {
            _service = service;
        }




        [HttpGet("getById/{userId}")]

        public async Task<IActionResult> GetById(string userId) {

            try {
                var user = await _service.GetUserById(userId);
                return Ok(user);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}

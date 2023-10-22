using api.API.Controllers.Common;
using api.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers {
    public class ProjectUserController : BaseController {
        private readonly IProjectUserService _projectUserService;

        public ProjectUserController(ILogger<ProjectUserController> logger, IProjectUserService projectUserService) : base(logger) {
            _projectUserService = projectUserService;
        }


        [Authorize]
        [HttpGet("getProjectsByUser/{userId}")]

        public async Task<IActionResult> GetProjectsByUser(string userId) {
        
            var projects =await _projectUserService.GetProjectsByUser(userId);

            return Ok(projects);
        
        }
    }
}

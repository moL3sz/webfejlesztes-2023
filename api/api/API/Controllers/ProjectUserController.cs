using api.API.Controllers.Common;
using api.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers {
    [Authorize]
    [Tags("Project - Felhasználó vezérlő")]
    public class ProjectUserController : BaseController {
        private readonly IProjectUserService _projectUserService;

        public ProjectUserController(ILogger<ProjectUserController> logger, IProjectUserService projectUserService) : base(logger) {
            _projectUserService = projectUserService;
        }


        [HttpGet("getProjectsByUser/{userId}")]
        public async Task<IActionResult> GetProjectsByUser(string userId) {
        
            var projects =await _projectUserService.GetProjectsByUser(userId);
            return Ok(projects);
        
        }


        [HttpGet("getUsersByProject/{projectId}")]
        public async Task<IActionResult> GetProjectsByUser(int projectId) {

            var users = await _projectUserService.GetUsersByProject(projectId);
            return Ok(users);

        }


        [HttpGet("getPendingProjectsByUser/{userId}")]
        public async Task<IActionResult> GetPendingProjectByUser(string userId) {

            var projects = await _projectUserService.GetPendingProjectByUser(userId);
            return Ok(projects);

        }

        [HttpPut("acceptProject/{projectId}")]
        public async Task<IActionResult> AcceptProjectByUser(int projectId) {
            try {
                await _projectUserService.AcceptProject(projectId);
                return Ok();
            }
            catch (Exception ex) {

                throw new Exception("Nem sikerült elfogadni a projektet", ex);
            }
        }
    }
}

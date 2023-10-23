using api.API.Controllers.Common;
using api.API.DTO.Project;
using api.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers {

    [Authorize]
    public class ProjectController : BaseController {

        private readonly IProjectService _service;
        private readonly IJWTHandler _jwt;

        public ProjectController(ILogger<ProjectController> logger, IProjectService service, IJWTHandler jwt) : base(logger) {
            _service = service;
           
            _jwt = jwt;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() {
            var projects = await _service.GetAll();
            return Ok(projects);
        }


        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> GetById(int Id) {
            var currentProject = await _service.GetById(Id);
            return Ok(currentProject);
        }


        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] ProjectFullDTO dto) {
            var newProject = await _service.Insert(dto);
            await _jwt.AddJWTToResponse(Response);
            return Ok(newProject);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectModifiableDTO modifiedDto) {
            var modifiedProject = await _service.Update(modifiedDto);
            return Ok(modifiedProject);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete(int Id) {
            var deletedProject = await _service.Delete(Id);
            return Ok(deletedProject);
        }

        [HttpGet("getProjectBurnDownChart/{projectId}")]
        
        public async Task<IActionResult> GetProjectBurnDownChart(int projectId) {
            var dataSet = await _service.GetProjectBurnDownChart(projectId);
            return Ok(dataSet);

        }

    }
}

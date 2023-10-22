using api.API.Controllers.Common;
using api.API.DTO.Project;
using api.BLL.Interfaces;
using api.Shared.Attributes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers {
    public class ProjectController : BaseController {

        private readonly IProjectService _service;
        private readonly Mapper _mapper;
        public ProjectController(ILogger<ProjectController> logger, IProjectService service) : base(logger) {
            _service = service;
            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<ProjectFullDTO, ProjectModifiableDTO>().ReverseMap();
            }));
            
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

    }
}

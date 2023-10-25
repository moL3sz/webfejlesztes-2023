using api.API.Controllers.Common;
using api.API.DTO.Common;
using api.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers {

    [Tags("Egyságes szótárkezelő vezérlő")]
    public class DictionaryManagerController : BaseController {
        private readonly IDictionaryService _service;

        public DictionaryManagerController(IDictionaryService service, ILogger<DictionaryManagerController> logger) : base(logger) {
            _service = service;
        }

        [HttpGet("{EntityName}/getAllByProject/{projectId}")]
        public async Task<List<BaseDictionaryDTO>> GetAllByProject(int projectId) {
            _service.ParseRequestUrl(Request.Path);
            return await _service.GetAllByProject(projectId);
        }

        [HttpGet("{EntityName}/getById/{Id}")]
        public async Task<BaseDictionaryDTO> GetById(int Id) {
            _service.ParseRequestUrl(Request.Path);
            return await _service.GetById(Id);
 
        }

        [HttpPost("{EntityName}/insert/{projectId}")]
        public async Task<IActionResult> Insert([FromBody] BaseDictionaryDTO dto, int projectId) {
            dto.ProjectId = projectId;
            _service.ParseRequestUrl(Request.Path);
            try {
                var newDto = await _service.Insert(dto);
                
                return Ok(newDto);
            }
            catch (Exception e) {

                return BadRequest(e.Message);
            }

        }

        [HttpPut("{EntityName}/update/{projectId}")]
        public async Task<IActionResult> Update([FromBody] BaseDictionaryDTO dto, int projectId) {
            dto.ProjectId = projectId;

            _service.ParseRequestUrl(Request.Path);
            try {
                var modifiedDto = await _service.Update(dto);
                return Ok(modifiedDto);
            }
            catch (Exception e) {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{EntityName}/delete/{Id}")]
        public async Task Delete(int Id) {

            _service.ParseRequestUrl(Request.Path);
            await _service.Delete(Id);
        }

    }
}

using api.API.Controllers.Common;
using api.API.DTO.Project;
using api.API.DTO.Ticket;
using api.BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers {
    public class TicketController : BaseController {

        private readonly ITicketService _service;
        private readonly Mapper _mapper;
        public TicketController(ILogger<TicketController> logger, ITicketService service) : base(logger) {
            _service = service;
            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<TicketFullViewDTO, TicketModifiableDTO>().ReverseMap();
            }));
            
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() {
            var Tickets = await _service.GetAll();
            return Ok(Tickets);
        }

        [HttpGet("getAllByProject/{projectId}")]
        public async Task<IActionResult> GetAll(int projectId) {
            var tickets = await _service.GetTicketsByProject(projectId);
            return Ok(tickets);
        }

        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> GetById(int Id) {
            var currentTicket = await _service.GetById(Id);
            return Ok(currentTicket);
        }


        [HttpPost("insert")]
        public async Task<IActionResult> Insert([FromBody] TicketFullViewDTO dto) {
            var newTicket = await _service.Insert(dto);
            return Ok(newTicket);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] TicketModifiableDTO modifiedDto) {
            var modifiedTicket = await _service.Update(modifiedDto);
            return Ok(modifiedTicket);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete(int Id) {
            var deletedTicket = await _service.Delete(Id);
            return Ok(deletedTicket);
        }

    }
}

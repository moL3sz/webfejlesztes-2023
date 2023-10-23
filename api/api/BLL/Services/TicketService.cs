using api.API.DTO.Project;
using api.API.DTO.Ticket;
using api.BLL.Interfaces;
using api.DAL.Entities;
using api.DAL.Entities.Dictionaries;
using api.DAL.Interfaces;
using api.DAL.Repositories;
using AutoMapper;

namespace api.BLL.Services {
    public class TicketService : ITicketService {

        private readonly ITicketRepository _repo;
        private readonly IMapper _mapper;
        private readonly IRecordInfoHelper _recordInfoHelper;

        public TicketService(
            ITicketRepository repo,
            IRecordInfoHelper recordInfoHelper,
            IMapper mapper
            ) {
            _repo = repo;
            _recordInfoHelper = recordInfoHelper;
            _mapper = mapper;
        }
        public async Task<List<TicketCompactDTO>> GetAll() {
            var Tickets = await _repo.GetAll();
            return _mapper.Map<List<TicketCompactDTO>>(Tickets);
        }

        public async Task<TicketFullViewDTO> GetById(int Id) {
            return _mapper.Map<TicketFullViewDTO>(await _repo.GetById(Id));
        }

        public async Task<TicketFullViewDTO> Insert(TicketFullViewDTO dto) {

            var entity = _mapper.Map<Ticket>(dto);
            _recordInfoHelper.SetNewRecordInfo(ref entity);
            entity = await _repo.Insert(entity);
            var newDto = _mapper.Map<TicketFullViewDTO>(entity);
            return newDto;


        }

        public async Task<TicketFullViewDTO> Update(dynamic dto) {
            var entity = _repo.PartialUpdate<Ticket>(dto);
            var modifiedDto = _mapper.Map<TicketModifiableDTO>(entity);
            return modifiedDto;
        }
        public async Task<TicketFullViewDTO> Delete(int id) {
            var deletedEntity = await _repo.Delete(id);
            return _mapper.Map<TicketFullViewDTO>(deletedEntity);
        }
        public async Task<List<TicketFullViewDTO>> GetTicketsByProject(int projectId) {
            var tickets = await _repo.GetByProject(projectId);
            return _mapper.Map<List<TicketFullViewDTO>>(tickets);
        }

        public bool IsTicketDone(Ticket ticket) {
            return ticket.Status?.NameL1 == "Befejezve";
        }
    }
}

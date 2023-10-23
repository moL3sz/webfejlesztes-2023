using api.API.DTO.Ticket;
using api.BLL.Interfaces.Common;
using api.DAL.Entities;

namespace api.BLL.Interfaces {
    public interface ITicketService: IBaseService<TicketCompactDTO, TicketFullViewDTO> {
        Task<List<TicketFullViewDTO>> GetTicketsByProject(int projectId);
        bool IsTicketDone(Ticket ticket);
    }
}

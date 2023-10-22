using api.API.DTO.Ticket;
using api.BLL.Interfaces.Common;

namespace api.BLL.Interfaces {
    public interface ITicketService: IBaseService<TicketCompactDTO, TicketFullDTO> {
    }
}

using api.DAL.Entities;
using api.DAL.Interfaces.Common;

namespace api.DAL.Interfaces {
    public interface ITicketRepository: IBaseRepository<Ticket>, IPartialUpdateHelper{

        Task<List<Ticket>> GetByProject(int projectId);
    }
}

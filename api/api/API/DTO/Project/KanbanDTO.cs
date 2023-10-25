using api.API.DTO.Common;
using api.API.DTO.Ticket;

namespace api.API.DTO.Project {
    public class KanbanDTO {
        
        /// <summary>
        /// Statusz
        /// </summry>
        public BaseDictionaryDTO? Status {get; set;}



        /// <summary>
        /// Státuszonkénti feladatok
        /// </summary>
        public List<TicketCompactDTO> Tickets { get; set;}
    }
}

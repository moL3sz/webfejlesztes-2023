using api.DAL.Entities.Common;
using api.DAL.Entities.Dictionaries;

namespace api.DAL.Entities {


    /// <summary>
    /// Feladat / Jegy
    /// </summary>
    public class Ticket : BaseEntity{

        /// <summary>
        /// Feladat címe
        /// </summary>
        public required string Title { get; set; }


        /// <summary>
        /// Feladat leírása
        /// </summary>
        public  string? Description { get; set; }

        // Navigation properties
        public virtual TicketCategory? Category { get; set; }
        public virtual TicketPriority? Priority { get; set; }
        public virtual TicketStatus? Status { get; set; }
        public required virtual User ResponsibleUser { get; set; }
    }
}

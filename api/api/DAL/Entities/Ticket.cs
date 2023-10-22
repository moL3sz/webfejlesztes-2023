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


        /// <summary>
        /// Jegy kategória
        /// </summary>
        public long? CategoryId { get; set; }

        /// <summary>
        /// Jegy prioritása
        /// </summary>
        public long? PriorityId { get; set; }

        /// <summary>
        /// Jegy státusza
        /// </summary>
        public long? StatusId { get; set; }


        /// <summary>
        /// Projeckt
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// Felelős személy
        /// </summary>
        public required long ResponsibleUserId { get; set; }


        // Navigation properties
        public virtual TicketCategory? Category { get; set; }
        public virtual TicketPriority? Priority { get; set; }
        public virtual TicketStatus? Status { get; set; }
        public required virtual User ResponsibleUser { get; set; }
    }
}

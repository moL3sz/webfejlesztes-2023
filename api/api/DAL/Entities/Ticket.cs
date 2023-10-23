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


        public int? CategoryId { get; set; }
        public int? PriorityId { get; set; }
        public int? StatusId { get; set; }

        public int ProjectId { get; set; }

        public string? ResponsibleUserId { get; set; }

        public DateTime? DeadLine {  get; set; }

        // Navigation properties




        /// <summary>
        /// Kategória
        /// </summary>
        public virtual TicketCategory? Category { get; set; }

        /// <summary>
        /// Priortás
        /// </summary>
        public virtual TicketPriority? Priority { get; set; }


        /// <summary>
        /// Státusz
        /// </summary>
        public virtual TicketStatus? Status { get; set; }

        /// <summary>
        /// Felelős személy
        /// </summary>
        public required virtual User ResponsibleUser { get; set; }


        /// <summary>
        /// Project
        /// </summary>
        public virtual Project Project { get; set; }
    }
}

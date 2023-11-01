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
        /// Ketgória
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Prioritás
        /// </summary>
        public int? PriorityId { get; set; }


        /// <summary>
        /// Státusz
        /// </summary>
        public int? StatusId { get; set; }


        /// <summary>
        /// Projekt
        /// </summary>
        public int ProjectId { get; set; }


        /// <summary>
        /// Felelős
        /// </summary>
        public string? ResponsibleUserId { get; set; }



        /// <summary>
        /// Határidő
        /// </summary>
        public DateTime? DeadLine {  get; set; }


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

namespace api.API.DTO.Ticket {

    /// <summary>
    /// Feladat / Jegy teljes
    /// </summary>
    public class TicketFullViewDTO {

        public int? Id { get; set; }

        /// <summary>
        /// Feladat címe
        /// </summary>
        public required string Title { get; set; }


        /// <summary>
        /// Feladat leírása
        /// </summary>
        public string? Description { get; set; }

        // Navigation properties

        /// <summary>
        /// Kategória
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Priortás
        /// </summary>
        public int? PriorityId { get; set; }


        /// <summary>
        /// Státusz
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// Project
        /// </summary>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Felelős személy
        /// </summary>
        public string? ResponsibleUserId { get; set; }

        /// <summary>
        /// Határidő
        /// </summary>
        public DateTime? DeadLine { get; set; }
    }
}

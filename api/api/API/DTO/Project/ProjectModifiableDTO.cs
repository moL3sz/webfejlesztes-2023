namespace api.API.DTO.Project {
    public class ProjectModifiableDTO {
        public int? Id { get; set; }

        public  string? Title { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}

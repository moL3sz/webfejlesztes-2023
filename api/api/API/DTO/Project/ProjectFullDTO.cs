namespace api.API.DTO.Project {
    public class ProjectFullDTO {

        public int? Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }

        public int? SprintLength { get; set; }
    }
}

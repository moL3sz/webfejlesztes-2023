namespace api.API.DTO.ProjectUser {
    public class ProjectUserDTO {
        public int? Id { get; set; }
        public int ProjectId { get; set; }

        public required string UserId { get; set; }

    }
}

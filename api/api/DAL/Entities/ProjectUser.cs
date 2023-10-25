using api.DAL.Entities.Common;

namespace api.DAL.Entities {
    public class ProjectUser : BaseEntity{


        public string UserId { get; set; }

        public int ProjectId { get; set; }

        public bool Accepted { get; set; }
        public DateTime? Acceptance {  get; set; }
        public required virtual User User { get; set; }
        public required virtual Project Project { get; set; }

    }
}

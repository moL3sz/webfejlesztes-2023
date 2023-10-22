using api.DAL.Entities.Common;

namespace api.DAL.Entities {
    public class ProjectUser : BaseEntity{

        public required virtual User User { get; set; }
        public required virtual Project Project { get; set; }

    }
}

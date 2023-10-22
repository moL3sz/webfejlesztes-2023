using api.DAL.Entities.Common;

namespace api.DAL.Entities {
    public class UserProject : BaseEntity{

        public required string UserId { get; set; }
        public required long ProjectId { get; set; }


        // Navigation properties
        public required virtual User User { get; set; }
        public required virtual Project Project { get; set; }

    }
}

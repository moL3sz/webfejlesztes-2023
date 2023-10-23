using api.DAL.Entities.Common;
using System.ComponentModel;

namespace api.DAL.Entities {
    public class Project : BaseEntity {

        public required string Title { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

        public DateTime Start {  get; set; }
        public DateTime End { get; set; }

        public required int SprintLenght { get; set; }



        // Navigation properties

        public virtual ICollection<ProjectUser> UserProjects { get; set; }
    }
}

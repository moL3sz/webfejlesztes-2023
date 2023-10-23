using api.API.DTO.Ticket;

namespace api.API.DTO.Project {
    public class ProjectBurnDownChartDTO {

        public DateTime Day { get; set; }

        public int? RemainingTasksCount => RemainingTasks.Count == 0 ? null : RemainingTasks.Count;
        public int ExpectedRemainingTasksCount {  get; set; }

        public List<string> RemainingTasks { get; set; } = new List<string>();

    }
}

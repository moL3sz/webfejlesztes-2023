using api.API.DTO.Project;
using api.API.DTO.Ticket;
using api.BLL.Interfaces.Common;

namespace api.BLL.Interfaces {
    public interface IProjectService : IBaseService<ProjectCompactDTO,ProjectFullDTO>{

        Task<List<ProjectBurnDownChartDTO>> GetProjectBurnDownChart(int projectId);

        Task<List<KanbanDTO>> GetKanbanBoard(int projectId);

    }
}

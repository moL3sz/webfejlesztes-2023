using api.API.DTO.Auth;
using api.API.DTO.Project;
using api.API.DTO.ProjectUser;

namespace api.BLL.Interfaces {
    public interface IProjectUserService {
        Task AddUserToProjectAsync(ProjectUserDTO dto);

        Task<List<ProjectCompactDTO>> GetProjectsByUser(string userId);
        Task<List<ProjectCompactDTO>> GetPendingProjectByUser(string userId);
        Task<List<UserDTO>> GetUsersByProject(int projectId);
        Task AcceptProject(int projectId);

        Task InvitePeople(MembersDTO members, int projectId);
    }
}

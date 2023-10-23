using api.API.DTO.Auth;
using api.API.DTO.Project;
using api.API.DTO.ProjectUser;
using api.DAL.Entities;

namespace api.BLL.Interfaces {
    public interface IProjectUserService {
        Task AddUserToProjectAsync(ProjectUserDTO dto);

        Task<List<ProjectCompactDTO>> GetProjectsByUser(string userId);
        Task<List<UserDTO>> GetUsersByProject(int projectId);
    }
}

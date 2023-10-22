using api.API.DTO.Auth;
using api.API.DTO.Project;
using api.DAL.Entities;

namespace api.BLL.Interfaces {
    public interface IProjectUserService {
        Task AddUserToProjectAsync(ProjectUser projectUser);

        Task<List<ProjectCompactDTO>> GetProjectsByUser(string userId);
        Task<List<UserDTO>> GetUsersByProject(long projectId);
    }
}

using api.DAL.Entities;

namespace api.DAL.Interfaces {
    public interface IProjectUserRepository {

        Task AddUserToProjectAsync(ProjectUser projectUser);

        Task<List<ProjectUser>> GetProjectsByUser(string userId);
        Task<List<User>> GetUsersByProject(int projectId);
        Task RemoveUserFromProjectAsync(ProjectUser projectUser);
        Task AcceptProject(string userId, int projectId);
    }
}

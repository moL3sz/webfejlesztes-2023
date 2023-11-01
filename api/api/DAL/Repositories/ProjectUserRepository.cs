using api.DAL.Context;
using api.DAL.Entities;
using api.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.DAL.Repositories {
    public class ProjectUserRepository : IProjectUserRepository {

        private readonly AppDbContext _db;

        public ProjectUserRepository(AppDbContext db) {
            _db = db;
        }

        public async Task AddUserToProjectAsync(ProjectUser projectUser) {

            _db.ProjectUsers.Add(projectUser);
            await _db.SaveChangesAsync();
        }
        public async Task BulkAddUsersToProjectAsync(IEnumerable<ProjectUser> projectUsers) {

            await _db.ProjectUsers.AddRangeAsync(projectUsers);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ProjectUser>> GetProjectsByUser(string userId) {
            return await _db.ProjectUsers
                .Include(x => x.Project)
                .Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<User>> GetUsersByProject(int projectId) {
            return await _db.ProjectUsers.Include(x => x.User)
             .Where(x => x.ProjectId == projectId).Select(x => x.User).ToListAsync();
        }

        public async Task RemoveUserFromProjectAsync(ProjectUser projectUser) {
            _db.ProjectUsers.Remove(projectUser);
            await _db.SaveChangesAsync();

        }
        public async Task AcceptProject(string userId, int projectId) {
            var projectUser = await _db.ProjectUsers.Where(x => x.UserId == userId && x.ProjectId == projectId).FirstOrDefaultAsync();
            if (projectUser == null) {
                throw new Exception($"ProjectUser not found with UserId:{userId} and ProjectId:{projectId}");
            }
            projectUser.Accepted = true;
            projectUser.Acceptance = DateTime.Now;
            await _db.SaveChangesAsync();

        }
    }
}

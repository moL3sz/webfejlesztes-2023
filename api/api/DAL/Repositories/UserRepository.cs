using api.DAL.Context;
using api.DAL.Entities;
using api.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.DAL.Repositories {
    public class UserRepository : IUserRepository {

        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) {
            _db = db;
        }

        public async Task<List<User>> GetAll() {
            return await _db.Users.ToListAsync();
        }

        public async Task AssignToProject(UserProject userProject) {
            await _db.UserProjects.AddAsync(userProject);
            await _db.SaveChangesAsync();
        }
    }
}

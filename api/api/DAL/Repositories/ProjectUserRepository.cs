﻿using api.DAL.Context;
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

        public async Task<List<Project>> GetProjectsByUser(string userId) {
            return await _db.ProjectUsers.Include(x=>x.User)
                .Include(x=>x.Project)
                .Where(x=>x.User.Id == userId).Select(x=>x.Project).ToListAsync();
        }

        public async Task<List<User>> GetUsersByProject(long projectId) {
            return await _db.ProjectUsers.Include(x => x.User)
             .Include(x => x.Project)
             .Where(x => x.Project.Id == projectId).Select(x => x.User).ToListAsync();
        }

        public async Task RemoveUserFromProjectAsync(ProjectUser projectUser) {
            _db.ProjectUsers.Remove(projectUser);
            await _db.SaveChangesAsync();

        }
    }
}

using api.DAL.Context;
using api.DAL.Entities;
using api.DAL.Interfaces;
using api.DAL.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace api.DAL.Repositories {
    public class ProjectRepository : IProjectRepository{

        private readonly AppDbContext _db;
        private readonly IPartialUpdateHelper _partialUpdater;

        public ProjectRepository(AppDbContext db, IPartialUpdateHelper partialUpdater) {
            _db = db;
            _partialUpdater = partialUpdater;
        }



        public async Task<List<Project>> GetAll() {
            return await _db.Projects.Where(x => x.Active && !x.Clone).ToListAsync();
        }

        public async Task<Project> GetById(int Id) {
            var entity = await _db.Projects.FindAsync(Id);

            if (entity == null) {
                throw new Exception($"Entity ({nameof(Project)}) not found with Id: {Id}");
            }
            return entity;

        }

        public async Task<Project> Insert(Project entity) {
            await _db.Projects.AddAsync(entity);
            var User = await _db.Users.FindAsync(entity.CreatorUserId);
           
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task<Project> Update(Project entity) {
            throw new NotImplementedException();
        }
        public async Task<Project> Delete(int id) {
            var entity = await this.GetById(id);
           
            entity.Active = false;
            _db.Projects.Update(entity);
            await _db.SaveChangesAsync();
            return entity;

        }

        // Handle partial update
        public T PartialUpdate<T>(object entity) where T : class {
            return _partialUpdater.PartialUpdate<T>(entity);
        }

        public object PartialUpdate(Type entityType, object entity) {
            return _partialUpdater.PartialUpdate(entityType, entity);
        }
    }
}

using api.DAL.Context;
using api.DAL.Entities;
using api.DAL.Interfaces;
using api.DAL.Interfaces.Common;
using Microsoft.EntityFrameworkCore;

namespace api.DAL.Repositories {
    public class UserRepository : IUserRepository, IPartialUpdateHelper {

        private readonly AppDbContext _db;
        private readonly IPartialUpdateHelper _partialUpdater;


        public UserRepository(AppDbContext db, IPartialUpdateHelper partialUpdater) {
            _db = db;
            _partialUpdater = partialUpdater;
        }
        public async Task<List<User>> GetAll() {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetById(int Id) {
            return await _db.Users.FindAsync(Id);
        }

        public async Task<User> Insert(User entity) {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task<User> Update(User entity) {
            throw new NotImplementedException();
        }
        public Task<User> Delete(int Id) {
            throw new NotImplementedException();
        }

        public T PartialUpdate<T>(object entity) where T : class {
            return _partialUpdater.PartialUpdate<T>(entity);
        }

        public object PartialUpdate(Type entityType, object entity) {
            return _partialUpdater.PartialUpdate(entityType, entity);
        }
    }
}

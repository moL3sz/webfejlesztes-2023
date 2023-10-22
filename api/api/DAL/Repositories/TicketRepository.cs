using api.DAL.Context;
using api.DAL.Entities;
using api.DAL.Interfaces.Common;
using api.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.DAL.Repositories {
    public class TicketRepository : ITicketRepository {

        private readonly AppDbContext _db;
        private readonly IPartialUpdateHelper _partialUpdater;

        public TicketRepository(AppDbContext db, IPartialUpdateHelper partialUpdater) {
            _db = db;
            _partialUpdater = partialUpdater;
        }



        public async Task<List<Ticket>> GetAll() {
            return await _db.Tickets.Where(x => x.Active && !x.Clone).ToListAsync();
        }

        public async Task<Ticket> GetById(int Id) {
            var entity = await _db.Tickets.FindAsync(Id);

            if (entity == null) {
                throw new Exception($"Entity ({nameof(Ticket)}) not found with Id: {Id}");
            }
            return entity;

        }

        public async Task<Ticket> Insert(Ticket entity) {
            await _db.Tickets.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task<Ticket> Update(Ticket entity) {
            throw new NotImplementedException();
        }
        public async Task<Ticket> Delete(int id) {
            var entity = await this.GetById(id);
            entity.Active = false;
            _db.Tickets.Update(entity);
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

using api.DAL.Entities;
using api.DAL.Entities.Dictionaries;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.DAL.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {


        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        // Dictionaries
        public virtual DbSet<TicketCategory> TicketCategories { get; set; }
        public virtual DbSet<TicketPriority> TicketPriorities { get; set; }
        public virtual DbSet<TicketStatus> TicketStatuses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }
    }
}

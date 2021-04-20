using Microsoft.EntityFrameworkCore;

namespace TimeTracking.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
         public DbSet<Team> Teams { get; set; }
        public DbSet<Tracking> Tracking { get; set; }

        
    }
}
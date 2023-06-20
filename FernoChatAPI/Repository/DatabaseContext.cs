using FernoChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FernoChatAPI.Repository
{
    public class DatabaseContext : DbContext
    {
        // Define your entity DbSet properties here

        public DbSet<Users> Users { get; set; }

        // Other entity DbSet properties

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here

            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserId);

            // Other entity configurations
        }
    }
}

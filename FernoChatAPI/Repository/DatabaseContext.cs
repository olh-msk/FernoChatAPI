using FernoChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FernoChatAPI.Repository
{
    public class DatabaseContext : DbContext
    {
        // Define your entity DbSet properties here

        public DbSet<User> Users { get; set; }

        public DbSet<Conversation> Conversations { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Conversation>()
                .HasKey(u => u.ConversationId);

            // Other entity configurations
        }
    }
}

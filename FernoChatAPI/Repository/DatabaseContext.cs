using FernoChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FernoChatAPI.Repository
{
    public class DatabaseContext : DbContext
    {
        // Define your entity DbSet properties here

        public DbSet<User> Users { get; set; }

        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<MessageAttachment> Attachments { get; set; }


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

            modelBuilder.Entity<Participant>()
                .HasKey(u => u.ParticipantId);

            modelBuilder.Entity<Message>()
                .HasKey(u => u.MessageId);

            modelBuilder.Entity<MessageAttachment>()
                .HasKey(u => u.AttachmentId);

            // Other entity configurations
        }
    }
}

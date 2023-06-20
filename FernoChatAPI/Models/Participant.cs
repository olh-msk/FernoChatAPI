using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FernoChatAPI.Models
{
    public class Participant
    {
        [Key]
        [Column("ParticipantId")]
        public int ParticipantId { get; set; }

        [Required]
        [Column("ConversationId")]
        public int ConversationId { get; set; }

        [Required]
        [Column("UserId")]
        public int UserId { get; set; }

        [ForeignKey("ConversationId")]
        public Conversation Conversation { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

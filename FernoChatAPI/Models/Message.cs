using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FernoChatAPI.Models
{
    public class Message
    {
        [Key]
        [Column("MessageId")]
        public int MessageId { get; set; }

        [Required]
        [Column("ConversationId")]
        public int ConversationId { get; set; }

        [Required]
        [Column("SenderUserId")]
        public int SenderUserId { get; set; }

        [Required]
        [Column("MessageContent")]
        public string MessageContent { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ConversationId")]
        public Conversation Conversation { get; set; }

        [ForeignKey("SenderUserId")]
        public User SenderUser { get; set; }
    }
}

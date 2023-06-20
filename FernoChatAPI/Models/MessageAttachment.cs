using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FernoChatAPI.Models
{
    public class MessageAttachment
    {
        [Key]
        [Column("AttachmentId")]
        public int AttachmentId { get; set; }

        [Required]
        [Column("MessageId")]
        public int MessageId { get; set; }

        [Required]
        [Column("FileName")]
        public string FileName { get; set; }

        [Required]
        [Column("FilePath")]
        public string FilePath { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("MessageId")]
        public Message Message { get; set; }
    }
}

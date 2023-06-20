using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FernoChatAPI.Models
{
    public class User
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Required]
        [Column("UserName")]
        public string UserName { get; set; }

        [Required]
        [Column("UserPassword")]
        public string UserPassword { get; set; }

        [Required]
        [Column("UserEmail")]
        public string UserEmail { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}

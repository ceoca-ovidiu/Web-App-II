using System.ComponentModel.DataAnnotations;

namespace Gourmet.Database
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string UserPassword { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string UserPhoneNumber { get; set; } = string.Empty;

    }
}

using System.ComponentModel.DataAnnotations;
using Gourmet.Database.Views;

namespace Gourmet.Database.Models
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

        public User() { }

        public User(UserVM userVM)
        {
            this.Username = userVM.Username;
            this.UserPassword = userVM.Password;
        }

        public User(UserSignUp userSignUp)
        {
            this.Username = userSignUp.Username;
            this.UserPassword = userSignUp.Password;
            this.UserEmail = userSignUp.Email;
            this.UserPhoneNumber = userSignUp.Phone;
        }
    }
}

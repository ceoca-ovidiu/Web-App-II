using System;


namespace Gourmet.Database.Views
{
    public class UserVM
    {
        public UserVM(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserSignUp
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class UserName
    {
        public string Username { get; set; }
    }
}
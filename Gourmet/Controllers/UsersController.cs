using Gourmet.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersRepository usersRepository;

        [HttpPost]
        [Route("signup")]
        public string SignUp([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return usersRepository.SignUp(user);
        }

        [HttpGet]
        [Route("login")]
        public string Login([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return usersRepository.Login(user);
        }

        [HttpGet]
        [Route("user")]
        public User GetUser([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return usersRepository.GetUser(user);
        }

        [HttpPut]
        [Route("changePassword")]
        public string ChangePassword([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return usersRepository.ChangePassword(user);
        }

        [HttpPut]
        [Route("changeEmail")]
        public string ChangeEmail([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return usersRepository.ChangeEmail(user);
        }

        [HttpPut]
        [Route("changePhone")]
        public string ChangePhone([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return usersRepository.ChangePhone(user);
        }

        [HttpGet]
        [Route("getUserByEmail")]
        public string GetUserByEmail([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            User userToBeReturned = usersRepository.GetUserByEmail(user);
            if (userToBeReturned == null)
            {
                return "The user could not be found";
            }
            else
            {
                return userToBeReturned.ToString();
            }
        }

        [HttpGet]
        [Route("getAllUsers")]
        public string GetAllUsers()
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            List<User> usersList = usersRepository.GetAllUsers();
            if (usersList == null)
            {
                return "The user list is empty";
            }
            else
            {
                return usersList.ToString();
            }
        }

        [HttpDelete]
        [Route("deleteUserByUsername")]
        public string DeleteUserByUsername([FromBody] User user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            if (usersRepository.DeleteUserByUsername(user))
            {
                return "The user has been deleted successfully";
            }
            else
            {
                return "The user could not be removed";
            }
        }
    }
}

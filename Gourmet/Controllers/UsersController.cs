using Gourmet.Database;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Gourmet.Database.Models;
using Gourmet.Database.Repositories;
using Gourmet.Database.Views;
namespace Gourmet.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersRepository usersRepository;

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<String>> SignUp([FromBody] UserSignUp user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return await usersRepository.SignUp(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserVM user)
        {
            if (this.usersRepository == null)
            {
                this.usersRepository = new UsersRepository();
            }
            var foundUser = await usersRepository.Login(user);
            if (foundUser == null)
            {
                return Ok("No user found");
            }
            else if (foundUser.Username.Equals("wrong pass") && foundUser.UserPassword.Equals("wrong pass"))
            {
                return Ok("Wrong password");
            }
            return Ok(foundUser);
        }

        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<User>> GetUser([FromBody] UserName user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            var found = await usersRepository.GetUser(user.Username);
            if (found == null)
            {
                return Ok("No user found");
            }
            return Ok(found);
        }

        [HttpPost]
        [Route("changePassword")]
        public async Task<ActionResult<string>> ChangePassword([FromBody] UserSignUp user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return Ok(await usersRepository.ChangePassword(user));
        }

        [HttpPost]
        [Route("changeEmail")]
        public async Task<ActionResult<string>> ChangeEmail([FromBody] UserSignUp user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return Ok(await usersRepository.ChangeEmail(user));
        }

        [HttpPost]
        [Route("changePhone")]
        public async Task<ActionResult<string>> ChangePhone([FromBody] UserSignUp user)
        {
            if (usersRepository == null)
            {
                usersRepository = new UsersRepository();
            }
            return Ok(await usersRepository.ChangePhone(user));
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

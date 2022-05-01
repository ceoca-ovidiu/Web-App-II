using Gourmet.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gourmet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersRepository usersRepository = new UsersRepository();

        [HttpPost]
        [Route("signup")]
        public string SignUp([FromBody] User user)
        {
            System.Diagnostics.Debug.WriteLine("########## AM INTRAT IN SIGN UP ##########");
            if (usersRepository.IsEmailCorrectWritten(user.UserEmail))
            {
                System.Diagnostics.Debug.WriteLine("########## EMAIL-UL ESTE CORECT ##########");
                if (usersRepository.IsUsernameValid(user.Username))
                {
                    System.Diagnostics.Debug.WriteLine("########## USERNAME-UL ESTE CORECT ##########");
                    if (usersRepository.IsPasswordValid(user.UserPassword, user.Username))
                    {
                        System.Diagnostics.Debug.WriteLine("########## PASSWORD-UL ESTE CORECT ##########");
                        usersRepository.CreateUser(user);
                        return "Sunt aici si am lipici si totul e OK";
                    }
                    else
                    {
                        return "Hai ca nu e ok 4";
                    }
                }
                else
                {
                    return "Hai ca nu e ok 3";
                }
            }
            else
            {
                return "Hai ca nu e ok 2";
            }
            return "Hai ca nu e ok 1";
        }

        [HttpGet]
        [Route("login")]
        public string Login([FromBody] User user)
        {
            System.Diagnostics.Debug.WriteLine("########## Totul este ok ##########");
            return "OK";
        }

        //[HttpGet]
        //[Route("test")]
        //public IActionResult Test()
        //{
        //    System.Diagnostics.Debug.WriteLine(
        //        "########## Totul este ok ##########");
        //    return Ok();
        //}
    }
}

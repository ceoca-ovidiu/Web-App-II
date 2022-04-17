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
        public IActionResult SignUp([FromBody] User user)
        {
            System.Diagnostics.Debug.WriteLine("########## AM INTRAT IN SIGN UP ##########");
            if (usersRepository.IsEmailCorrectWritten(user.UserEmail))
            {
                System.Diagnostics.Debug.WriteLine("########## EMAIL-UL ESTE CORECT ##########");
                if (usersRepository.IsUsernameValid(user.Username))
                {
                    System.Diagnostics.Debug.WriteLine("########## USERNAME-UL ESTE CORECT ##########");
                    if (usersRepository.IsPasswordValid(user.UserPassword))
                    {
                        System.Diagnostics.Debug.WriteLine("########## PASSWORD-UL ESTE CORECT ##########");
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            System.Diagnostics.Debug.WriteLine("########## Totul este ok ##########");
            return Ok();
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

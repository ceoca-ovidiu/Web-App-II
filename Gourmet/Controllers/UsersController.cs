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
            System.Diagnostics.Debug.WriteLine(user.Username);
            System.Diagnostics.Debug.WriteLine(user.UserEmail);
            System.Diagnostics.Debug.WriteLine(user.UserPassword);
            //System.Diagnostics.Debug.WriteLine("########## AM INTRAT IN SIGN UP ##########");
            
            //if (usersRepository.IsEmailCorrectWritten(user.UserEmail))
            //{
                    if (usersRepository.IsPasswordValid(user.UserPassword, user.Username))
            //    if (usersRepository.IsUsernameValid(user.Username))
            //    {
                        usersRepository.CreateUser(user);
                        return "Sunt aici si am lipici si totul e OK";
            //        {
            //            System.Diagnostics.Debug.WriteLine("########## PASSWORD-UL ESTE CORECT ##########");
            //            return Ok();
                        return "Hai ca nu e ok 4";
            //        else
            //        {
            //            return BadRequest();
            //        }
                    return "Hai ca nu e ok 3";
            //    else
            //    {
            //        return BadRequest();
            //    }
                return "Hai ca nu e ok 2";
            //else
            return "Hai ca nu e ok 1";
            //    return BadRequest();
            //}
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

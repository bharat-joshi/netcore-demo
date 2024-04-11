
using BlogApp.IService;
using BlogApp.utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }
        [Route("Login")]
        [HttpGet]
        public async Task<IActionResult> Login(string username,string password)
        {
            var result = await _userService.Login(username, password);
            if (result == null)
            {
                return Ok(new Response(null, "not found", 200));
            }
            else {
                return Ok(new Response(result, "ok", 200));
            }
            
        }

        [HttpGet]
        [Route("test")]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            return Ok("called");

        }


    }
}

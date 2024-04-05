using BlogApp.Dtos;
using BlogApp.Entity;
using BlogApp.IService;
using BlogApp.utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserService _userService;
        public UserController(IUserService userService) {
            this._userService = userService;
        }

        [HttpGet]
        public async  Task<IActionResult> getUsers()
        {

            var data = await _userService.GetUsers();

            return Ok(new Response(data,"ok",200));
            //return Ok(new Response(data,"done",200));

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}

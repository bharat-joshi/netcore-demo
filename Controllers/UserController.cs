using AutoMapper;
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
        IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper) {
            this._userService = userService;
            this._mapper = mapper;

        }

        [HttpGet]
        public async  Task<IActionResult> getUsers()
        {

            var data = await _userService.GetUsers();
            var userdata = _mapper.Map<UserDto>(data);
            return Ok(new Response(userdata, "ok",200));
            //return Ok(new Response(data,"done",200));

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var data = await _userService.AddUser(_mapper.Map<User>(userDto));
            return Ok();
        }
    }
}

using System;
using System.Threading.Tasks;
using Mesi.Io.Api.User.Domain;
using Mesi.Io.Api.User.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Mesi.Io.Api.User.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest registration)
        {
            var registeredUser = await _userService.Register(registration.Email, registration.Password, registration.Username);
            return Created($"/api/user/{registeredUser.UserName}", new {username = registeredUser.UserName, email = registeredUser.Email});
        }

        [HttpPost("jwt/token")]
        public async Task<IActionResult> Token([FromBody] AuthenticationRequest authentication)
        {
            var user = await _userService.Authenticate(authentication.Email, authentication.Password);
            if (user == null) return Unauthorized(new {message = "Invalid credentials"});
            
            var token = _userService.GenerateJWT(user);

            return Ok(new {jwt = token});
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var user = await _userService.GetByName(name);
            if (user == null) return NoContent();

            return Ok(new {id = user.UserId,username = user.UserName, email = user.Email, roles = user.Roles});
        }
    }
}
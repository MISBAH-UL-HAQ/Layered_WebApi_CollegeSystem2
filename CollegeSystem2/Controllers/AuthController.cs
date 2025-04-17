using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CollegeSystem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //        private readonly IAuthService _authService;

        //        public AuthController(IAuthService authService)
        //        {
        //            _authService = authService;
        //        }

        //        [HttpPost("Register")]
        //        public async Task<ActionResult<string>> CreateUserAsync([FromBody] RegisterUserDto register)
        //        {
        //            var result = await _authService.RegisterAsync(register);

        //            if (result.StartsWith("User registered"))
        //                return Ok(result);
        //            else
        //                return StatusCode(500, result); // return 500 if registration fails
        //        }

        //        [HttpPost("Login")]
        //        public async Task<ActionResult<string>> LoginAsync([FromBody] UserLoginDto user)
        //        {
        //            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
        //            {
        //                return BadRequest("Please enter valid email and password");
        //            }

        //            var token = await _authService.LoginAsync(user);
        //            return Ok(token);
        //        }

        //        [HttpGet("Logout")]
        //        public async Task<ActionResult<string>> LogoutAsync()
        //        {
        //            var status = await _authService.LogOutAsync();
        //            return Ok(status);
        //        }
        //    }
        //}

        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var resp = await _auth.RegisterAsync(dto);
            return resp.Token == null && resp.Message.StartsWith("User registered")
                ? Ok(resp)
                : StatusCode(500, resp);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var resp = await _auth.LoginAsync(dto);
            return resp.Token == null ? Unauthorized(resp) : Ok(resp);
        }

        [Authorize]
        [HttpGet("Profile")]
        public IActionResult Profile()
        {
            return Ok(new
            {
                User = User.Identity.Name,
                Message = "This is a protected endpoint"
            });
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var resp = await _auth.LogOutAsync();
            return Ok(resp);
        }
    }
}
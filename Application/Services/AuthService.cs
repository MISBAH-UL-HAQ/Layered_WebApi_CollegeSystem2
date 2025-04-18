using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Application.Interfaces;
using Domain.Entities;
namespace Application.Services
{
    //    public class AuthService : IAuthService
    //    {

    //        private readonly UserManager<RegisterUser> _userManager;
    //        private readonly SignInManager<RegisterUser> _signInManager;
    //        private readonly IConfiguration _config;
    //        public AuthService(
    //            UserManager<RegisterUser> userManager,
    //            SignInManager<RegisterUser> signInManager,
    //            IConfiguration config)
    //        {
    //            _userManager = userManager;
    //            _signInManager = signInManager;
    //            _config = config;
    //        }

    //        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto registerDto)
    //        {
    //            var user = new RegisterUser
    //            {
    //                UserName = registerDto.Email,
    //                Email = registerDto.Email,
    //                FullName = registerDto.FullName,
    //                DepartmentId = registerDto.DepartmentId
    //            };

    //            var result = await _userManager.CreateAsync(user, registerDto.Password);

    //            if (!result.Succeeded)
    //                return new AuthResponseDto { Message = string.Join(", ", result.Errors.Select(e => e.Description)) };

    //            return new AuthResponseDto { Message = "Registration successful" };
    //        }

    //        public async Task<AuthResponseDto> LoginAsync(UserLoginDto loginDto)
    //        {
    //            var user = await _userManager.FindByEmailAsync(loginDto.Email);
    //            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
    //                return new AuthResponseDto { Message = "Invalid credentials" };

    //            var tokenHandler = new JwtSecurityTokenHandler();
    //            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

    //            var tokenDescriptor = new SecurityTokenDescriptor
    //            {
    //                Subject = new ClaimsIdentity(new[]
    //                {
    //                new Claim(ClaimTypes.NameIdentifier, user.Id),
    //                new Claim(ClaimTypes.Email, user.Email)
    //            }),
    //                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiryMinutes"])),
    //                SigningCredentials = new SigningCredentials(
    //                    new SymmetricSecurityKey(key),
    //                    SecurityAlgorithms.HmacSha256Signature)
    //            };

    //            var token = tokenHandler.CreateToken(tokenDescriptor);
    //            return new AuthResponseDto
    //            {
    //                Token = tokenHandler.WriteToken(token),
    //                Message = "Login successful"
    //            };
    //        }

    //        //public async Task LogoutAsync() => await _signInManager.SignOutAsync();
    //        public async Task<AuthResponseDto> LogOutAsync()
    //        {
    //            await _signInManager.SignOutAsync();
    //            return new AuthResponseDto { Message = "Logout successful" };
    //        }

    //    }
    //}
    public class AuthService : IAuthService
    {
        private readonly IAuthService _authRepository;

        public AuthService(IAuthService authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto registerDto)
            => await _authRepository.RegisterAsync(registerDto);

        public async Task<AuthResponseDto> LoginAsync(UserLoginDto loginDto)
            => await _authRepository.LoginAsync(loginDto);

        public async Task<AuthResponseDto> LogOutAsync()
            => await _authRepository.LogOutAsync();
    }
}
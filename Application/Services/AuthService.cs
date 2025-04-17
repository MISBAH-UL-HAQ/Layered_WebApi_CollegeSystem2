using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Interfaces;




namespace Application.Services
{
    //public class AuthService : IAuthService
    //{

    //        private readonly UserManager<RegisterUser> _userManager;
    //        private readonly SignInManager<RegisterUser> _signInManager;
    //        private readonly IConfiguration _config;

    //        public AuthService(UserManager<RegisterUser> userManager,
    //                           SignInManager<RegisterUser> signInManager,
    //                           IConfiguration config)
    //        {
    //            _userManager = userManager;
    //            _signInManager = signInManager;
    //            _config = config;
    //        }

    //        public async Task<string> RegisterAsync(RegisterUserDto registerUserDto)
    //        {
    //            // Create a RegisterUser instance from the DTO.
    //            var user = new RegisterUser
    //            {
    //                UserName = registerUserDto.Email,
    //                Email = registerUserDto.Email,
    //                FullName = registerUserDto.FullName,
    //                DepartmentId = registerUserDto.DepartmentId

    //            };

    //            // Create the user using Identity.
    //            var result = await _userManager.CreateAsync(user, registerUserDto.Password);
    //            if (!result.Succeeded)
    //            {
    //                // Return all error messages as a single string.
    //                return string.Join(", ", result.Errors.Select(e => e.Description));
    //            }

    //            return "User registered successfully!";
    //        }

    //        public async Task<string> LoginAsync(UserLoginDto loginUserDto)
    //        {
    //            // Find the user by email.
    //            var user = await _userManager.FindByEmailAsync(loginUserDto.Email);
    //            if (user == null)
    //            {
    //                return "Invalid credentials.";
    //            }

    //            // Verify the password.
    //            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);
    //            if (!result.Succeeded)
    //            {
    //                return "Invalid credentials.";
    //            }

    //            // Create JWT claims.
    //            var claims = new[]
    //            {
    //                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
    //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //                new Claim(ClaimTypes.Name, user.FullName),
    //                new Claim(ClaimTypes.Email, user.Email)
    //            };

    //            // Get the security key from configuration.
    //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    //            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //            // Set token expiration.
    //            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiryMinutes"]));

    //            // Create the JWT token.
    //            var token = new JwtSecurityToken(
    //                issuer: _config["Jwt:Issuer"],
    //                audience: _config["Jwt:Audience"],
    //                claims: claims,
    //                expires: expiration,
    //                signingCredentials: creds);

    //            // Return the generated token.
    //            return new JwtSecurityTokenHandler().WriteToken(token);
    //        }

    //        public async Task<string> LogOutAsync()
    //        {
    //            // For JWT, logging out on the server doesn't do much since the token is stateless.
    //            // But if using cookie authentication, you would call SignOutAsync.
    //            await _signInManager.SignOutAsync();
    //            return "Logged out successfully!";
    //        }
    //    }
    //}





    //public class AuthService : IAuthService
    //{

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

    //        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
    //        {
    //            var user = new RegisterUser
    //            {
    //                Email = dto.Email,
    //                UserName = dto.Email,
    //                FullName = dto.FullName,
    //                DepartmentId = dto.DepartmentId
    //            };

    //            var result = await _userManager.CreateAsync(user, dto.Password);
    //            if (!result.Succeeded)
    //            {
    //                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
    //                return new AuthResponseDto { Token = null, Message = errors };
    //            }

    //            // Optionally add to role
    //            await _userManager.AddToRoleAsync(user, dto.Role);

    //            return new AuthResponseDto { Token = null, Message = "User registered successfully" };
    //        }

    //        public async Task<AuthResponseDto> LoginAsync(UserLoginDto dto)
    //        {
    //            var user = await _userManager.FindByEmailAsync(dto.Email);
    //            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
    //            {
    //                return new AuthResponseDto { Token = null, Message = "Invalid email or password" };
    //            }

    //            // Build JWT
    //            var claims = new List<Claim>
    //            {
    //                new Claim(ClaimTypes.Name, user.UserName),
    //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //            };

    //            var keyBytes = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
    //            var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);
    //            var expires = DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:ExpiryMinutes"]));

    //            var token = new JwtSecurityToken(
    //                issuer: _config["Jwt:Issuer"],
    //                audience: _config["Jwt:Audience"],
    //                claims: claims,
    //                expires: expires,
    //                signingCredentials: creds);

    //            return new AuthResponseDto
    //            {
    //                Token = new JwtSecurityTokenHandler().WriteToken(token),
    //                Message = "Login successful"
    //            };
    //        }

    //        public async Task<AuthResponseDto> LogOutAsync()
    //        {
    //            await _signInManager.SignOutAsync();
    //            return new AuthResponseDto { Token = null, Message = "Logged out successfully" };
    //        }
    //    }
    //}




    public class AuthService : IAuthService
    {
        private readonly UserManager<RegisterUser> _userManager;
        private readonly SignInManager<RegisterUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<RegisterUser> userManager, SignInManager<RegisterUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            var user = new RegisterUser { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return new AuthResponseDto { Token = null, Message = "User registration failed" };

            return new AuthResponseDto { Token = null, Message = "User registered successfully" };
        }

        public async Task<AuthResponseDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return new AuthResponseDto { Token = null, Message = "Invalid login attempt" };

            var token = await GenerateJwtToken(user);

            return new AuthResponseDto { Token = token, Message = "Login successful" };
        }

        public async Task<AuthResponseDto> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return new AuthResponseDto { Token = null, Message = "User logged out successfully" };
        }

        private async Task<string> GenerateJwtToken(RegisterUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
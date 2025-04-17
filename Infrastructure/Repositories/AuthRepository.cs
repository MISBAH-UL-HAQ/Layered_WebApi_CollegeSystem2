using Application.DTOs;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        public AuthRepository(
        UserManager<ApplicationUser> userManager,
            IConfiguration config
        )
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            var user = new ApplicationUser
            {
                FullName = dto.FullName,
                UserName = dto.Email,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            return new AuthResponseDto
            {
                Message = result.Succeeded ? "User registered!" : string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

        public async Task<AuthResponseDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return new AuthResponseDto { Message = "Invalid credentials" };

            // Generate JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("DepartmentId", user.DepartmentId.ToString())  // Include DepartmentId
                }),
                Expires = DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_config["Jwt:ExpiryMinutes"])
                ),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthResponseDto
            {
                Token = tokenHandler.WriteToken(token),
                Message = "Login successful!"
            };
        }
    }
}
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces;
namespace Application.Interfaces
{

    //        public interface IAuthService
    //        {
    //            Task<AuthResponseDto> RegisterAsync(RegisterUserDto registerUserDto);
    //            Task<AuthResponseDto> LoginAsync(UserLoginDto loginUserDto);
    //            Task<AuthResponseDto> LogOutAsync();
    //        }

    //}



    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto);
        Task<AuthResponseDto> LoginAsync(UserLoginDto dto);
        Task<AuthResponseDto> LogOutAsync();
    }
}
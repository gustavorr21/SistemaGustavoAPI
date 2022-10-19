using Microsoft.AspNetCore.Identity;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.Application.Accounts
{
    public interface IAccountService
    {
        Task<bool> UserExists(string userName);
        Task<UserDto> GetUserByNameAsync(string userName);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<SignInResult> CheckPasswordAsync(UserDto userUpdtateDto, string password);
        Task<SalvarUsuarioResult> CreateAccountAsync(UserDto userDto);
        Task<SalvarUsuarioResult> UpdateAccount(AtualizarUsuarioDtoRequest userUpdtateDto);
    }
}

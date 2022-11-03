using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
using Sistema.Domain.Identity;
using Sistema.Repository.Repositorys.Usuario;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Sistema.Application.Application.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;

        public AccountService(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserRepository userRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<SignInResult> CheckPasswordAsync(UserDto userUpdtateDto, string password)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(u=>u.UserName == userUpdtateDto.UserName.ToLower());

                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar a senha");

            }
        }

        public async Task<SalvarUsuarioResult> CreateAccountAsync(UserDto userDto)
        {
            try
            {
                var newUsuario = new User(userDto.PrimeiroNome,
                                            userDto.UltimoNome,
                                            userDto.Titulo,
                                            userDto.Email,
                                            userDto.Descricao,
                                            userDto.Funcao);
                newUsuario.UserName = userDto.UserName;
                var result = await _userManager.CreateAsync(newUsuario, userDto.Password);

                //var result = await _userManager.CreateAsync(newUsuario, user.Password);

                return new SalvarUsuarioResult((UserDto)newUsuario);  
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar usuario");
            }
        }

        public async Task<UserDto> GetUserByNameAsync(string userName)
        {
            try
            {
                return await _userRepository.GetUserByNameAsync(userName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar usuario por nome");

            }
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _userRepository.GetUserByIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar usuario por nome");

            }
        }

        public async Task<SalvarUsuarioResult> UpdateAccount(AtualizarUsuarioDtoRequest userUpdtateDto)
        {
            try
            {
                User userUp = await _userRepository.GetUserByIdAsync(userUpdtateDto.User.Id)
                   ?? throw new ObjectNotFoundException("Usuario não encontrado!");

                if (userUpdtateDto.User.Password != null) { 
                    var token = await _userManager.GeneratePasswordResetTokenAsync(userUp);
                    var result = await _userManager.ResetPasswordAsync(userUp, token, userUpdtateDto.User.Password);
                }

                //este serve como base, so ir implementando
                userUp.AtualizarPrimeiroNome(userUpdtateDto.User.PrimeiroNome);
                userUp.AtualizarUltimoNome(userUpdtateDto.User.UltimoNome);
                userUp.AtualizarEmail(userUpdtateDto.User.Email);
                userUp.AtualizarPassword(userUpdtateDto.User.Password);
                userUp.AtualizarDescricao(userUpdtateDto.User.Descricao);
                userUp.AtualizarTitulo(userUpdtateDto.User.Titulo);
                userUp.AtualizarFuncao(userUpdtateDto.User.Funcao);
                userUp.AtualizarTelefone(userUpdtateDto.User.PhoneNumber);

                _userRepository.Update<User>(userUp);

                await _userRepository.SaveChangesAsync();

                return new SalvarUsuarioResult((UserDto)userUp);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar usuario");

            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await _userManager.Users.AnyAsync(u => u.UserName == userName.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar se usuario existe");

            }
        }
    }
}

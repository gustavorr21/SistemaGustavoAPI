using Infra.Http.Seedwork.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Application.Application.Accounts;
using Sistema.Application.Application.Token;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
using Sistema.Domain.Identity;
using SistemaGustavoAPI.Extensions;
using System;
using System.Threading.Tasks;

namespace SistemaGustavoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        public AccountController(IAccountService accountService,
                                ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }
        [HttpGet("GetUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userId = User.GetUserId();
                return Ok(await _accountService.GetUserByIdAsync(userId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("incluir-usuario")]
        [AllowAnonymous]
        public async Task<IActionResult> IncluirUsuario(CriarUsuarioDtoRequest userRequest)
        {
            try
            {
                if (await _accountService.UserExists(userRequest.User.UserName))
                    return BadRequest("Usuario já existente");

                var user = await _accountService.CreateAccountAsync(userRequest.User);
                
                return Ok(new
                {
                    userName = user.Result.UserName,
                    primeiroNome = user.Result.PrimeiroNome,
                    token = (await _tokenService.CreateToken(user.Result)).ToString()
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto loginRequest)
        {
            try
            {
                var user = await _accountService.GetUserByNameAsync(loginRequest.UserName);
                if (user == null) return Unauthorized("Usuário invalido");

                var result = await _accountService.CheckPasswordAsync(user, loginRequest.Password);
                if (!result.Succeeded) return Unauthorized("Usuário invalido");

                return Ok(new { 
                    userName = user.UserName,
                    primeiroNome = user.PrimeiroNome,
                    token = (await _tokenService.CreateToken(user)).ToString()
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("atualizar-usuario")]
        public async Task<IActionResult> UpdateUser(AtualizarUsuarioDtoRequest userUpdateDto)
        {
            try
            {
                if (userUpdateDto.User.UserName != User.GetUserName().ToString())
                    return Unauthorized("Usuário Inválido");

                var user = await _accountService.GetUserByNameAsync(User.GetUserName());
                if (user == null) return Unauthorized("Usuário Inválido");

                var userReturn = await _accountService.UpdateAccount(userUpdateDto);
                if (userReturn == null) return NoContent();

                return Ok(new
                {
                    userName = userReturn.Result.UserName,
                    PrimeroNome = userReturn.Result.PrimeiroNome,
                    token = _tokenService.CreateToken(userReturn.Result).Result
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

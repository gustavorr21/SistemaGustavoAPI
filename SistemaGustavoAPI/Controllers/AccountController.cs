using Infra.Http.Seedwork.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Application.Application.Accounts;
using Sistema.Application.Application.Token;
using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
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
        [HttpGet("GetUser/{userName}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser(string userName)
        {
            try
            {
                return Ok(await _accountService.GetUserByNameAsync(userName));
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

                return Ok(await _accountService.CreateAccountAsync(userRequest.User));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.Application.Token
{
    public interface ITokenService
    {
        Task<string> CreateToken(CriarUsuarioDtoRequest salvarUsuarioResult);
    }
}

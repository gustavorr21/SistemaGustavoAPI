using Sistema.Domain.Enum;
using Sistema.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public Titulo Titulo { get; set; }
        public string UserName{ get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Funcao Funcao { get; set; }
        public string Descricao { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public static implicit operator UserDto(User user)
        {
            if (user is null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                PrimeiroNome = user.PrimeiroNome,
                Titulo = user.Titulo,
                UserName = user.UserName,
                UltimoNome = user.UltimoNome,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Funcao = user.Funcao,
                Descricao = user.Descricao,
                Token = user.Token,
            };
        }
    }
}


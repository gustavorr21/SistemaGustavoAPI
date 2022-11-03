using Sistema.Domain.Identity;
using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

        public static implicit operator PalestranteDto(Palestrante palestrante)
        {
            if (palestrante is null)
                return null;

            return new PalestranteDto
            {
                Id = palestrante.Id,
                Nome = palestrante.Nome,
                MiniCurriculo= palestrante.MiniCurriculo,
                UserId = palestrante.UserId,
                Telefone = palestrante.Telefone,
                Email = palestrante.Email,
                ImagemURL = palestrante.ImagemURL,
                RedesSociais = palestrante.RedesSociais,
                PalestrantesEventos = palestrante.PalestrantesEventos,
            };
        }
    }
}

using Sistema.Domain.Identity;
using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Dtos
{
    public class SalvarPalestranteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public List<RedeSocial> RedesSociais { get; set; } = new List<RedeSocial>();
        public List<PalestranteEvento> PalestrantesEventos { get; set; } = new List<PalestranteEvento>();
    }
}

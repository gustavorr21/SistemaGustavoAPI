using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Dtos
{
    public class SalvarEventoDto
    {
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public string QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public List<SalvarLoteDto> Lotes { get; set; } = new List<SalvarLoteDto>();
        public List<RedeSocial> RedesSociais { get; set; } = new List<RedeSocial>();
        public List<PalestranteEvento> PalestrantesEventos { get; set; } = new List<PalestranteEvento>();

    }
}

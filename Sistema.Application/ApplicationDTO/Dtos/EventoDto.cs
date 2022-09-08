using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public string QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

        public static implicit operator EventoDto(EventoOcorrido evento)
        {
            if (evento is null)
                return null;

            return new EventoDto
            {
                Local = evento.Local,
            };
        }
    }
}

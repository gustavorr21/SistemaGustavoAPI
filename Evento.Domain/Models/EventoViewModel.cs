using System;
using System.Collections;
using System.Collections.Generic;

namespace Evento.Domain.Models
{
    public class EventoViewModel
    {
        public string Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public string QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<LoteViewModel> Lotes { get; set; }
        public IEnumerable<RedeSocialViewModel> RedesSociais { get; set; }
        public IEnumerable<PalestranteEventoViewModel> PalestrantesEventos { get; set; }
    }
}

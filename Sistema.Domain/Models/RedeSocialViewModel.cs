using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Domain.Models
{
    public class RedeSocialViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public EventoViewModel Evento { get; set; }
        public int? PalestranteId { get; set; }
        public PalestranteViewModel Palestrante{ get; set; }
    }
}

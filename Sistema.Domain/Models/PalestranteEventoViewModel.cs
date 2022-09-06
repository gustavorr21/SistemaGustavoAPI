using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Domain.Models
{
    public class PalestranteEventoViewModel
    {
        public int PalestranteId { get; set; }
        public PalestranteViewModel Palestrante { get; set; }
        public int EventoId { get; set; }
        public EventoViewModel Evento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Domain.Models
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public EventoOcorrido Evento { get; set; }
    }
}

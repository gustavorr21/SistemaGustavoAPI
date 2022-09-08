using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Requests
{
    public class PesquisarEventoFilterRequest
    {
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
    }
}

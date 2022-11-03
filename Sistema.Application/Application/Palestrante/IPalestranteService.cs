using Sistema.Application.ApplicationDTO.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.Application.Palestrante
{
    public interface IPalestranteService
    {
        Task<IEnumerable<PalestranteDto>> GetAllPalestranteAsync();
    }
}

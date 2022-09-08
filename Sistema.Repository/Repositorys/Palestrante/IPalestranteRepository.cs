using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repository.Repositorys.Palestrante
{
    public interface IPalestranteRepository
    {
        Task<ICollection<Domain.Models.Palestrante>> GetPalestranteByFilterAsync(string tema);
        Task<ICollection<Domain.Models.Palestrante>> GetAllPalestranteAsync();
        Task<Domain.Models.Palestrante> GetAllPalestranteByIdAsync(int Id);
    }
}

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
        Task<ICollection<PalestranteViewModel>> GetPalestranteByFilterAsync(string tema);
        Task<ICollection<PalestranteViewModel>> GetAllPalestranteAsync();
        Task<PalestranteViewModel> GetAllPalestranteByIdAsync(int Id);
    }
}

using Sistema.Domain.Models;
using Sistema.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repository.Repositorys.Palestrante
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly ApplicationDbContext _context;
        public PalestranteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<PalestranteViewModel>> GetAllPalestranteAsync()
        {
            IQueryable<PalestranteViewModel> query =
               _context.Palestrantes
               .Include(e => e.RedesSociais)
               .Include(e => e.PalestrantesEventos)
                   .ThenInclude(pe => pe.Evento)
               .AsNoTracking();

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<PalestranteViewModel> GetAllPalestranteByIdAsync(int Id)
        {
            IQueryable<PalestranteViewModel> query =
             _context.Palestrantes
             .Include(p => p.RedesSociais)
             .Include(p => p.PalestrantesEventos)
                 .ThenInclude(pe => pe.Evento)
             .AsNoTracking()
             .Where(p => p.Id == Id);

            query = query.OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ICollection<PalestranteViewModel>> GetPalestranteByFilterAsync(string nome)
        {
            IQueryable<PalestranteViewModel> query =
             _context.Palestrantes
             .Include(p => p.RedesSociais)
             .Include(p => p.PalestrantesEventos)
                 .ThenInclude(pe => pe.Evento)
             .AsNoTracking();

            if (nome != null)
                query = query.Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}

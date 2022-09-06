using Sistema.Domain.Models;
using Sistema.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repository.Repositorys.Evento
{
    public class EventoRepository : IEventosRepository
    {
        private readonly ApplicationDbContext _context;
        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<EventoViewModel>> GetAllEventosAsync()
        {
            IQueryable<EventoViewModel> query =
                _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais)
                .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante)
                .AsNoTracking();

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }
        public async Task<ICollection<EventoViewModel>> GetEventosByFilterAsync(string tema)
        {
            IQueryable<EventoViewModel> query =
               _context.Eventos
               .Include(e => e.Lotes)
               .Include(e => e.RedesSociais)
               .Include(e => e.PalestrantesEventos)
                   .ThenInclude(pe => pe.Palestrante)
               .AsNoTracking();

            if (tema != null)
                query = query.Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }
        public async Task<EventoViewModel> GetAllEventosByIdAsync(int Id)
        {
            IQueryable<EventoViewModel> query =
               _context.Eventos
               .Include(e => e.Lotes)
               .Include(e => e.RedesSociais)
               .Include(e => e.PalestrantesEventos)
                   .ThenInclude(pe => pe.Palestrante)
               .AsNoTracking()
               .Where(e => e.Id == Id);

            query = query.OrderBy(e => e.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}

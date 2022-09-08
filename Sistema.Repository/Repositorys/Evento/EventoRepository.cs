using Sistema.Domain.Models;
using Sistema.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linx.Infra.Data;

namespace Sistema.Repository.Repositorys.Evento
{
    public class EventoRepository :/* Repository<EventoOcorrido>,*/ IEventosRepository
    {
        private readonly ApplicationDbContext _context;
        public EventoRepository(ApplicationDbContext context /*IEFUnitOfWork unitOfWork*/) /*: base(unitOfWork)*/
        {
            _context = context;
        }
        public async Task<IEnumerable<EventoOcorrido>> GetAllEventosAsync()
        {
            IQueryable<EventoOcorrido> query =
                _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais)
                .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante)
                .AsNoTracking();

            query = query.OrderBy(e => e.Id);

            return await query.ToListAsync();
        }
        public async Task<ICollection<EventoOcorrido>> GetEventosByFilterAsync(string tema)
        {
            IQueryable<EventoOcorrido> query =
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
        public async Task<EventoOcorrido> GetAllEventosByIdAsync(int Id)
        {
            return await
               _context.Eventos
               .Include(e => e.Lotes)
               .Include(e => e.RedesSociais)
               .Include(e => e.PalestrantesEventos)
                   .ThenInclude(pe => pe.Palestrante)
               .AsNoTracking()
               .Where(e => e.Id == Id)
                .OrderBy(e => e.Id)
                .FirstOrDefaultAsync();
        }
    }
}

using Linx.Infra.Crosscutting;
using Linx.Infra.Data.Query;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.RepositorysQuery.Repositories
{
    public class EventoQueryRepository : QueryRepository<EventoOcorrido, EventoDto>, IEventoQueryRepository
    {
        public EventoQueryRepository(IEFQueryUnitOfWork unitOfWork)
            : base(unitOfWork) 
        {
        }

        public async Task<IPagedCollection<EventoDto>> FindAsync(
            string descricao,
            string modelo,
            int? tipoId,
            Pagination pagination)
        {
            return null;
            //IQueryable<EventoOcorrido> query = UnitOfWork
            //                                .Set<Equipamento>()
            //                                .AsNoTracking()
            //                                .Include(x => x.Tecnologia)
            //                                .Include(e => e.Tipo);

            //if (!string.IsNullOrWhiteSpace(descricao))
            //{
            //    query = query.Where(p => p.Descricao.ToUpper().Contains(descricao.ToUpper()));
            //}

            //if (!string.IsNullOrWhiteSpace(modelo))
            //{
            //    query = query.Where(p => p.Modelo.ToUpper().Contains(modelo.ToUpper()));
            //}

            //if (tipoId.HasValue)
            //{
            //    query = query.Where(p => p.TipoId == tipoId);
            //}

            //IPagedCollection<Equipamento> equipamentos = await query.PaginateListAsync(pagination);

            //return equipamentos
            //    .Select(p => ParseResult(p));
        }

        private static EventoDto ParseResult(EventoOcorrido obj)
        {
            return (EventoDto)obj;
        }
    }
}

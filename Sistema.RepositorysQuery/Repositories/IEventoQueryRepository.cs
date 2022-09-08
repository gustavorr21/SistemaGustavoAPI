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
    public interface IEventoQueryRepository : IQueryRepository<EventoOcorrido, EventoDto>
    {
        Task<IPagedCollection<EventoDto>> FindAsync(string descricao, string modelo, int? tipoId, Pagination pagination);
    }
}

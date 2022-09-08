using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linx.Infra.Data;

namespace Sistema.RepositoryQuery.Repositories
{
    public class EventoQueryRepository : QueryRepository<EventoOcorrido, EventoDto>, IEventoQueryRepository
    {
        public EventoQueryRepository()
        {

        }

    }
}

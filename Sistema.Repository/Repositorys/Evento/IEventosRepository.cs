using Linx.Domain;
using Linx.Infra.Crosscutting;
using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repository.Repositorys.Evento
{
    public interface IEventoRepository
    {
        Task<ICollection<EventoOcorrido>> GetEventosByFilterAsync(string tema);
        Task<IEnumerable<EventoOcorrido>> GetAllEventosAsync();
        Task<EventoOcorrido> GetAllEventosByIdAsync(int Id);
    }
}

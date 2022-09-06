using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repository.Repositorys.Evento
{
    public interface IEventosRepository
    {
        Task<ICollection<EventoViewModel>> GetEventosByFilterAsync(string tema);
        Task<ICollection<EventoViewModel>> GetAllEventosAsync();
        Task<EventoViewModel> GetAllEventosByIdAsync(int Id);
    }
}

using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.Application.Evento
{
    public interface IEventoService
    {
        Task<EventoViewModel> AddEvento(EventoViewModel evento);
        Task<EventoViewModel> UpdateEvento(int Id, EventoViewModel evento);
        Task<bool> DeleteEvento(int Id);
        Task<ICollection<EventoViewModel>> GetEventosByFilterAsync(string tema);
        Task<ICollection<EventoViewModel>> GetAllEventosAsync();
        Task<EventoViewModel> GetAllEventosByIdAsync(int Id);
    }
}

using Sistema.Domain.Models;
using Sistema.Repository.Repositorys.Evento;
using Sistema.Repository.Repositorys.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.Application.Evento
{
    public class EventoService : IEventoService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IEventosRepository _eventoRepository;
        public EventoService(IGeralRepository geralRepository, IEventosRepository eventoRepository)
        {
            _geralRepository = geralRepository;
            _eventoRepository = eventoRepository;
        }
        public Task<EventoViewModel> AddEvento(EventoViewModel evento)
        {
            try
            {
                _geralRepository.Add<EventoViewModel>(evento);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoViewModel> UpdateEvento(int Id, EventoViewModel evento)
        {
            try
            {
                var eventUp = await _eventoRepository.GetAllEventosByIdAsync(Id);
                if (eventUp == null) return null;

                evento.Id = eventUp.Id;

                _geralRepository.Update<EventoViewModel>(evento);
                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int Id)
        {
            try
            {
                var evento = await _eventoRepository.GetAllEventosByIdAsync(Id);
                if (evento == null) throw new Exception("Evento não encontrado");

                _geralRepository.Delete<EventoViewModel>(evento);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<EventoViewModel>> GetAllEventosAsync()
        {
            try
            {
                var evento = await _eventoRepository.GetAllEventosAsync();
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoViewModel> GetAllEventosByIdAsync(int Id)
        {
            try
            {
                var evento = await _eventoRepository.GetAllEventosByIdAsync(Id);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<EventoViewModel>> GetEventosByFilterAsync(string tema)
        {
            try
            {
                var evento = await _eventoRepository.GetEventosByFilterAsync(tema);
                if (evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

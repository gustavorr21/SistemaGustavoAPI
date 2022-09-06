using Sistema.Application.Application.Evento;
using Sistema.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Sistema.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SistemaGustavoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _eventoService.GetAllEventosAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("incluir-evento")]
        public async Task<IActionResult> SalvarEvento(EventoViewModel evento)
        {
            try
            {
                return Ok(await _eventoService.AddEvento(evento));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEvento(int id, EventoViewModel evento)
        {
            try
            {
                return Ok(await _eventoService.UpdateEvento(id, evento));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEvento(int id)
        {
            try
            {
                return Ok(await _eventoService.DeleteEvento(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

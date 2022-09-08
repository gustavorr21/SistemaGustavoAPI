using Sistema.Application.Application.Evento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Linx.Application.Results;
using Linx.Infra.Crosscutting.Requests;
using Infra.Http.Seedwork.Controllers;

namespace SistemaGustavoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ApiController
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

        [HttpGet("{id:long}")]
        public async Task<IActionResult> ObterGrupo([FromRoute] int id)
        {
            EventoDto equipamento = await _eventoService.GetAllEventosByIdAsync(id);

            if (equipamento is null)
            {
                return NotFound(new ApiResult(new ApiError("Equipamento não encontrado")));
            }

            return Ok(equipamento);
        }

        [HttpGet("pesquisar")]
        public async Task<IActionResult> ListarEvento([FromQuery] PesquisarEventoFilterRequest filtro, [FromQuery] PaginationRequest pagination)
        {
            return Paged(await _eventoService.PesquisarEvento(filtro, pagination));
        }

        [HttpPost("incluir-evento")]
        public async Task<IActionResult> SalvarEvento([FromBody] CriarEventoRequest request)
        {
            try
            {
                return Ok(await _eventoService.AddEvento(request));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id:long}")]
        public async Task<IActionResult> AtualizarEvento([FromRoute] int id, [FromBody] AtualizarEventoRequest request)
        {
            try
            {
                return Ok(await _eventoService.UpdateEvento(id, request));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeletarEvento([FromRoute] int id)
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

using Sistema.Application.Application.Evento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Linx.Application.Results;
using Linx.Infra.Crosscutting.Requests;
using Infra.Http.Seedwork.Controllers;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SistemaGustavoAPI.Extensions;

namespace SistemaGustavoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ApiController
    {
        private readonly IEventoService _eventoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventoController(IEventoService eventoService,
            IWebHostEnvironment webHostEnvironment)
        {
            _eventoService = eventoService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                long userId = User.GetUserId();
                return Ok(await _eventoService.GetAllEventosAsync(userId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> ObterGrupo([FromRoute] int id)
        {
            EventoDto evento = await _eventoService.GetAllEventosByIdAsync(id);

            if (evento is null)
            {
                return NotFound(new ApiResult(new ApiError("Equipamento não encontrado")));
            }

            return Ok(evento);
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
                //EventoDto evento = await _eventoService.GetAllEventosByIdAsync(id);

                //var imagemPath = Path.Combine(_webHostEnvironment.ContentRootPath, @"Resources/Imagens", evento.ImagemUrl);
                //var eventoRetorno = await _eventoService.DeletarImagem(id, imagemPath);
                return Ok(await _eventoService.DeleteEvento(id));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("upload-imagem/{eventoId:long}")]
        public async Task<IActionResult> UploadImagem([FromRoute] int eventoId, IFormFile filea)
        {
            try
            {
                EventoDto evento = await _eventoService.GetAllEventosByIdAsync(eventoId);

                if (evento is null)
                {
                    return NotFound(new ApiResult(new ApiError("Equipamento não encontrado")));
                }

                var file = Request.Form.Files[0];
                if(file.Length > 0)
                {
                    //deletar imagem
                    var imagemPath = Path.Combine(_webHostEnvironment.ContentRootPath, @"Resources/Imagens", evento.ImagemUrl);
                    var eventoRetorno = await _eventoService.DeletarImagem(eventoId, imagemPath);

                    string imageName = new String(Path.GetFileNameWithoutExtension(file.FileName)
                                       .Take(10)
                                       .ToArray()).Replace(" ", "-");
                    imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(file.FileName)}";

                    var newImagemPath = Path.Combine(_webHostEnvironment.ContentRootPath, @"Resources/Imagens", imageName);

                    return Ok(await _eventoService.SaveImagem(file, newImagemPath, eventoId, imageName));
                }

                return NotFound("Imagem não encontrada");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

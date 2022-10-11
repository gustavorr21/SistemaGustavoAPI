using Linx.Infra.Crosscutting;
using Linx.Infra.Crosscutting.Requests;
using Microsoft.AspNetCore.Http;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
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
        Task<SalvarEventoResult> AddEvento(CriarEventoRequest evento);
        Task<SalvarEventoResult> UpdateEvento(int Id, AtualizarEventoRequest evento);
        Task<ExcluirEventoResult> DeleteEvento(int Id);
        Task<IEnumerable<EventoDto>> GetEventosByFilterAsync(string tema);
        Task<IEnumerable<EventoDto>> GetAllEventosAsync();
        Task<EventoDto> GetAllEventosByIdAsync(int Id);
        Task<IPagedCollection<EventoDto>> PesquisarEvento(PesquisarEventoFilterRequest filtro, PaginationRequest pagination);
        Task<SalvarEventoResult> DeletarImagem(int eventoId, string imagemPath);
        Task<SalvarEventoResult> SaveImagem(IFormFile imagemFile, string newImagem, int eventoId, string imageName);
    }
}

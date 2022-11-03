using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Linx.Infra.Crosscutting;
using Linx.Infra.Crosscutting.Exceptions;
using Linx.Infra.Crosscutting.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
using Sistema.Domain.Models;
using Sistema.Repository.Repositorys.Evento;
using Sistema.Repository.Repositorys.Geral;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace Sistema.Application.Application.Evento
{
    public class EventoService : IEventoService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IEventoRepository _eventoRepository;
        //private readonly IEventoQueryRepository _eventoQueryRepository;
        public EventoService(IGeralRepository geralRepository, IEventoRepository eventoRepository)
        {
            _geralRepository = geralRepository;
            _eventoRepository = eventoRepository;
        }
        public async Task<SalvarEventoResult> AddEvento(CriarEventoRequest evento)
        {
            try
            {
                Lote eventoLote;
                var newEvento = new EventoOcorrido(evento.Evento.Local,
                                              evento.Evento.Tema,
                                              evento.Evento.QtdPessoas,
                                              evento.Evento.ImagemUrl,
                                              evento.Evento.Telefone,
                                              evento.Evento.Email);
                newEvento.AtualizarDataEvento(DateTime.Now);

                foreach (var model in evento.Evento.Lotes)
                {
                    eventoLote = new Lote(model.Nome, model.Preco,model.DataFim,model.DataFim, model.Quantidade,0);
                    newEvento.IncluirLotes(eventoLote);
                }

                _geralRepository.Add<EventoOcorrido>(newEvento);
                await _geralRepository.SaveChangesAsync();

                return new SalvarEventoResult((EventoDto)newEvento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<SalvarEventoResult> UpdateEvento(int id, AtualizarEventoRequest request)
        {
            try
            {
                EventoOcorrido eventUp = await _eventoRepository.GetAllEventosByIdAsync(id)
                    ?? throw new ObjectNotFoundException("Evento não encontrado!");

                eventUp.AtualizarDataEvento(request.Evento.DataEvento);
                eventUp.AtualizarLocal(request.Evento.Local);
                eventUp.AtualizarEmail(request.Evento.Email);
                //eventUp.AtualizarImagemUrl(request.Evento.ImagemUrl);
                eventUp.AtualizarQtdPessoas(request.Evento.QtdPessoas);
                eventUp.AtualizarTelefone(request.Evento.Telefone);
                eventUp.AtualizarTema(request.Evento.Tema);


                //atualizar/remover  lotes
                foreach(SalvarLoteDto item in request.Evento.Lotes)
                {
                    Lote lote = null;

                    var eventoLoteId = item.Id;

                    if(eventoLoteId > 0)
                    {
                        lote = eventUp.Lotes.FirstOrDefault(x => x.Id == eventoLoteId);

                        if (item.Remover)
                        {
                            if (lote != null)
                                _geralRepository.Delete<Lote>(lote);
                            continue;
                        }
                    }

                    if(lote is null)
                        lote = new Lote(item.Nome, item.Preco, item.DataFim, item.DataFim, item.Quantidade, id);

                    lote.AtualizarNome(item.Nome);
                    lote.AtualizarPreco(item.Preco);
                    lote.AtualizarDataInicio(item.DataInicio);
                    lote.AtualizarDataFim(item.DataFim);
                    lote.AtualizarQuantidade(item.Quantidade);

                    eventUp.AtualizarLote(lote);
                }

                _geralRepository.Update<EventoOcorrido>(eventUp);
                await _geralRepository.SaveChangesAsync();

                return new SalvarEventoResult((EventoDto)eventUp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ExcluirEventoResult> DeleteEvento(int id)
        {
            try
            {
                EventoOcorrido evento = await _eventoRepository.GetAllEventosByIdAsync(id)
                    ?? throw new ObjectNotFoundException("Evento não encontrado!");

                await DeletarImagem(evento.Id, evento.ImagemUrl);

                _geralRepository.Delete<EventoOcorrido>(evento);
                await _geralRepository.SaveChangesAsync();

                return new ExcluirEventoResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventoDto>> GetAllEventosAsync(long userId)
        {
            try
            {
                IEnumerable<EventoOcorrido> evento = await _eventoRepository.GetAllEventosAsync(userId);

                return evento?.Select(eq => (EventoDto)eq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetAllEventosByIdAsync(int Id)
        {
            try
            {
                return await _eventoRepository.GetAllEventosByIdAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<EventoDto>> GetEventosByFilterAsync(string tema)
        {
            try
            {
                var evento = await _eventoRepository.GetEventosByFilterAsync(tema);
                if (evento == null) return null;

                return evento?.Select(eq => (EventoDto)eq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IPagedCollection<EventoDto>> PesquisarEvento(
         PesquisarEventoFilterRequest filtro,
         PaginationRequest pagination)
        {
            return null;
            //return await _eventoRepository.FindAsync(
            //    filtro.Descricao,
            //    filtro.Modelo,
            //    filtro.TipoId,
            //    pagination.ToPagination());
        }

        public async Task<SalvarEventoResult> DeletarImagem(int eventoId, string imagemPath)
        {
            var evento = await _eventoRepository.GetAllEventosByIdAsync(eventoId);
            if (System.IO.File.Exists(imagemPath))
                   System.IO.File.Delete(imagemPath);

            //_geralRepository.Update<EventoOcorrido>(evento);
            //await _geralRepository.SaveChangesAsync();

            return new SalvarEventoResult((EventoDto)evento);
        }

        public async Task<SalvarEventoResult> SaveImagem(IFormFile imagemFile, string newImagem, int eventoId, string imageName)
        {
            var evento = await _eventoRepository.GetAllEventosByIdAsync(eventoId);

            using (var fileSteam = new FileStream(newImagem, FileMode.Create))
            {
                await imagemFile.CopyToAsync(fileSteam);
            }

            evento.AtualizarImagemUrl(imageName);

            _geralRepository.Update<EventoOcorrido>(evento);
            await _geralRepository.SaveChangesAsync();

            return new SalvarEventoResult((EventoDto)evento);
        }
        public async Task<SalvarLoteResult> AddLote(int eventoId, Lote lote)
        {
            try
            {
                var newLote = new Lote(lote.Nome,
                                              lote.Preco,
                                              lote.DataInicio,
                                              lote.DataFim,
                                              lote.Quantidade,
                                              eventoId);

                _geralRepository.Add<Lote>(newLote);
                //await _geralRepository.SaveChangesAsync();

                return new SalvarLoteResult((LotesDto)newLote);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using Sistema.Application.ApplicationDTO.Dtos;
using Sistema.Application.ApplicationDTO.Requests;
using Sistema.Application.ApplicationDTO.Result;
using Sistema.Domain.Models;
using Sistema.Repository.Repositorys.Evento;
using Sistema.Repository.Repositorys.Geral;
using Sistema.Repository.Repositorys.Palestrante;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.Application.Palestrante
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IPalestranteRepository _palestranteRepository;

        public PalestranteService(IGeralRepository geralRepository, IPalestranteRepository palestranteRepository)
        {
            _geralRepository = geralRepository;
            _palestranteRepository = palestranteRepository;
        }
        public async Task<IEnumerable<PalestranteDto>> GetAllPalestranteAsync()
        {
            try
            {
                IEnumerable<Domain.Models.Palestrante> palestrantes = await _palestranteRepository.GetAllPalestranteAsync();

                return palestrantes?.Select(eq => (PalestranteDto)eq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SalvarPalestranteResult> AddPalestrantes(int userId, CriarPalestranteRequest model)
        {
            try
            {
                try
                {
                    var newPalestrante = new Domain.Models.Palestrante(model.Palestrante.Nome,
                                                  model.Palestrante.MiniCurriculo,
                                                  model.Palestrante.Telefone,
                                                  model.Palestrante.ImagemURL,
                                                  model.Palestrante.Email);

                    _geralRepository.Add<Domain.Models.Palestrante>(newPalestrante);
                    await _geralRepository.SaveChangesAsync();

                    return new SalvarPalestranteResult((PalestranteDto)newPalestrante);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SalvarPalestranteResult> UpdatePalestrante(int userId, AtualizarPalestranteRequest model)
        {
            try
            {
                Domain.Models.Palestrante palestranteUp = (Domain.Models.Palestrante)(await _palestranteRepository.GetPalestranteByFilterAsync(null,userId)
                    ?? throw new ObjectNotFoundException("Palestrante não encontrado!"));

                palestranteUp.AtualizarMiniCurriculo(model.Palestrante.MiniCurriculo);

                _geralRepository.Update<Domain.Models.Palestrante>(palestranteUp);
                await _geralRepository.SaveChangesAsync();

                return new SalvarPalestranteResult((PalestranteDto)palestranteUp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PalestranteDto>> GetPalestranteByUserIdAsync(int userId, bool includeEventos = false)
        {
            try
            {
                IEnumerable<Domain.Models.Palestrante> evento = await _palestranteRepository.GetPalestranteByFilterAsync(null,userId);

                return evento?.Select(eq => (PalestranteDto)eq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

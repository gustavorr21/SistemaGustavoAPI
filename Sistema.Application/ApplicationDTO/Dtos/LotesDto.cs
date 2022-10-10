using Sistema.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Application.ApplicationDTO.Dtos
{
    public class LotesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public EventoOcorrido Evento { get; set; }


        public static implicit operator LotesDto(Lote lote)
        {
            if (lote is null)
                return null;

            return new LotesDto
            {
                Id = lote.Id,
                Nome = lote.Nome,
                Preco = lote.Preco,
                DataInicio = lote.DataInicio,
                DataFim = lote.DataFim,
                Quantidade = lote.Quantidade,
                EventoId = lote.EventoId,
                Evento = lote.Evento,
            };
        }
    }
}

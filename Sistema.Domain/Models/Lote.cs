using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Domain.Models
{
    public class Lote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public EventoOcorrido Evento { get; set; }



        protected Lote() : base() { }

        public Lote(string nome,
                           decimal preco,
                           DateTime? dataInicio,
                           DateTime? dataFim,
                           int quantidade,
                           int eventoId)
            : this()
        {
            AtualizarNome(nome);
            AtualizarPreco(preco);
            AtualizarDataInicio(dataInicio);
            AtualizarDataFim(dataFim);
            AtualizarQuantidade(quantidade);
            AtualizarEventoId(eventoId);
        }

        public void AtualizarDataInicio(DateTime? dataInicio)
        {
            DataInicio = dataInicio;
        }
        public void AtualizarDataFim(DateTime? dataFim)
        {
            DataFim = dataFim;
        }
        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarPreco(decimal preco)
        {
            Preco = preco;
        }
        public void AtualizarQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
        public void AtualizarEventoId(int eventoId)
        {
            EventoId = eventoId;
        }
    }
}

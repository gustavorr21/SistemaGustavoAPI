using Linx.Domain;
using Linx.Infra.Crosscutting;
using Sistema.Domain.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Domain.Models
{
    public class EventoOcorrido : Entity
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public string QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        //public IEnumerable<Lote> Lotes { get; set; }

        public ICollection<Lote> Lotes { get; private set; } = new List<Lote>();
        public ICollection<RedeSocial> RedesSociais { get; private set; } = new List<RedeSocial>();
        public ICollection<PalestranteEvento> PalestrantesEventos { get; private set; } = new List<PalestranteEvento>();


        protected EventoOcorrido() : base() { }

        public EventoOcorrido(string local,
                           string tema,
                           string qtdPessoas,
                           string imagemUrl,
                           string telefone,
                           string email)
            : this()
        {
            AtualizarLocal(local);
            AtualizarTema(tema);
            AtualizarQtdPessoas(qtdPessoas);
            AtualizarImagemUrl(imagemUrl);
            AtualizarTelefone(telefone);
            AtualizarEmail(email);
        }

        public void IncluirLotes(Lote lotes)
        {
            Lotes.Add(lotes);
        }
        public void RemoverLote(Lote lotes)
        {
            Lotes.Remove(lotes);
        }
        public void AtualizarLote(Lote lote)
        {
            Lote loteDb = Lotes.FirstOrDefault(x => x.Id == lote.Id);

            if (loteDb == null || loteDb.Id == 0)
            {
                Lotes.Add(lote);
            }
            else
            {
                loteDb = lote;
            }
        }

        public void AtualizarDataEvento(DateTime? dataEvento)
        {
            DataEvento = dataEvento;
        }
        public void AtualizarLocal(string local)
        {
            Local = local;
        }
        public void AtualizarTema(string tema)
        {
            Tema = tema;
        }
        public void AtualizarImagem(string imagem)
        {
            ImagemUrl = imagem;
        }
        public void AtualizarQtdPessoas(string qtdPessoas)
        {
            QtdPessoas = qtdPessoas;
        }
        public void AtualizarImagemUrl(string imagemUrl)
        {
            ImagemUrl = imagemUrl;
        }
        public void AtualizarTelefone(string telefone)
        {
            Telefone = telefone;
        }
        public void AtualizarEmail(string email)
        {
            Email = email;
        }
    }
}

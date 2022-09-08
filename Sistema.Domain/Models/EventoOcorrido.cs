using Linx.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

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
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }


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

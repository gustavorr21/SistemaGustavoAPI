using Linx.Domain;
using Sistema.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Domain.Models
{
    public class Palestrante : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }



        protected Palestrante() : base() { }

        public Palestrante(string nome,
                           string miniCurriculo,
                           string telefone,
                           string imagemUrl,
                           string email)
            : this()
        {
            AtualizarNome(nome);
            AtualizarMiniCurriculo(miniCurriculo);
            AtualizarImagem(imagemUrl);
            AtualizarTelefone(telefone);
            AtualizarEmail(email);
        }
        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarMiniCurriculo(string miniCurriculo)
        {
            MiniCurriculo = miniCurriculo;
        }
        public void AtualizarImagem(string imagem)
        {
            ImagemURL = imagem;
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

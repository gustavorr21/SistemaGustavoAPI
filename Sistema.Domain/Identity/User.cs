using Microsoft.AspNetCore.Identity;
using Sistema.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public Titulo Titulo { get; set; }
        public string Descricao { get; set; }
        public string Password { get; set; }
        public Funcao Funcao { get; set; }
        public string ImagemUrl { get; set; }
        public List<UserRole> UserRoles{ get; set; }

        [NotMapped]
        public string Token { get; set; }
        protected User() : base() { }
        public User(string primeiroNome,
                           string ultimoNome,
                           Titulo titulo,
                           string email,
                           string descricao,
                           Funcao funcao)
            : this()
        {
            AtualizarPrimeiroNome(primeiroNome);
            AtualizarUltimoNome(ultimoNome);
            AtualizarDescricao(descricao);
            AtualizarFuncao(funcao);
            AtualizarTitulo(titulo);
            AtualizarEmail(email);
            //AtualizarImagem(imagemUrl);
        }

        public void AtualizarPrimeiroNome(string primeiroNome)
        {
            PrimeiroNome = primeiroNome;
        }
        public void AtualizarUltimoNome(string ultimoNome)
        {
            UltimoNome = ultimoNome;
        }
        public void AtualizarEmail(string email)
        {
            Email = email;
        }
        public void AtualizarPassword(string password)
        {
            Password = password;
        }
        public void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void AtualizarTitulo(Titulo titulo)
        {
            Titulo = titulo;
        }
        public void AtualizarFuncao(Funcao funcao)
        {
            Funcao = funcao;
        }
        public void AtualizarImagem(string imagemUrl)
        {
            ImagemUrl = imagemUrl;
        }
    }
}

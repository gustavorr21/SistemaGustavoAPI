using Evento.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Evento.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventoViewModel> Eventos { get; set; }
        public DbSet<LoteViewModel> Lotes { get; set; }
        public DbSet<PalestranteViewModel> Palestrantes { get; set; }
        public DbSet<PalestranteEventoViewModel> PalestrantesEventos { get; set; }
        public DbSet<RedeSocialViewModel> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEventoViewModel>()
                        .HasKey(pe => new { pe.EventoId, pe.PalestranteId });

            base.OnModelCreating(modelBuilder);
        }

    }
}

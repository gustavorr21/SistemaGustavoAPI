using Sistema.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sistema.Repository.Data
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

            modelBuilder.Entity<EventoViewModel>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PalestranteViewModel>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}

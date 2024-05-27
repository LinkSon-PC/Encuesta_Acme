using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Encuesta_Acme
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<EncuestaRespuesta> EncuestaRespuestas { get; set; }
        public DbSet<EncuestaCampoRespuesta> EncuestaCampoRespuesta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Encuesta>()
                .HasMany(c => c.Campos)
                .WithOne(e => e.Encuesta)
                .HasForeignKey(e => e.EncuestaId);

            modelBuilder.Entity<Encuesta>()
                .HasMany(s => s.EncuestaRespuestas)
                .WithOne(r => r.Encuesta)
                .HasForeignKey(r => r.EncuestaId);

            modelBuilder.Entity<EncuestaRespuesta>()
                .HasMany(e => e.CampoRespuestas)
                .WithOne(r => r.EncuestaRespuesta)
                .HasForeignKey(e => e.EncuestaRespuestaId);

            modelBuilder.Entity<Campo>()
                .HasMany(f => f.CampoRespuestas)
                .WithOne(fr => fr.Campo)
                .HasForeignKey(fr => fr.CampoId);

            modelBuilder.Entity<Campo>()
                .Property(e => e.TipoCampo)
                .HasConversion<string>();
        }
    }
}

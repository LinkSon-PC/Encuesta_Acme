using Encuesta_Acme.Entidades;
using Encuesta_Acme.Models;
using Microsoft.EntityFrameworkCore;

namespace Encuesta_Acme
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<EncuestaRespuesta> EncuestaRespuestas { get; set; }
        public DbSet<EncuestaCampoRespuesta> EncuesatCampoRespuesta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Encuesta>()
                .HasMany(c => c.Campos)
                .WithOne(e => e.Encuesta)
                .HasForeignKey(e => e.EncuestaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Campo>()
                .Property(e => e.TipoCampo)
                .HasConversion<string>();

            modelBuilder.Entity<EncuestaRespuesta>()
                .HasMany(e => e.CampoRespuestas)
                .WithOne(r => r.EncuestaRespuesta)
                .HasForeignKey(e => e.EncuestaRespuestaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EncuestaCampoRespuesta>()
                .HasOne(fr => fr.EncuestaRespuesta)
                .WithMany()
                .HasForeignKey(fr => fr.EncuestaRespuestaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EncuestaCampoRespuesta>()
                .HasOne(e => e.EncuestaRespuesta)
                .WithMany(r => r.CampoRespuestas)
                .HasForeignKey(r => r.EncuestaRespuestaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

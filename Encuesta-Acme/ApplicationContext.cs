using Encuesta_Acme.Models;
using Microsoft.EntityFrameworkCore;

namespace Encuesta_Acme
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encuesta>()
                .HasMany(c => c.Campos)
                .WithOne(e => e.Encuesta)
                .HasForeignKey(e => e.EncuestaId);

            modelBuilder.Entity<Campo>()
                .Property(e => e.TipoCampo)
                .HasConversion<string>();
        }
    }
}

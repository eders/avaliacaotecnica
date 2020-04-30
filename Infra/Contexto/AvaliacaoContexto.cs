using Dominio.Entidades;
using Entidades;
using Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexto
{
    public class AvaliacaoContexto : DbContext
    {
        public AvaliacaoContexto(DbContextOptions<AvaliacaoContexto> options) : base(options) { }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>(new MarcaMapeamento().Configure);
            modelBuilder.Entity<Modelo>(new ModeloMapeamento().Configure);
            modelBuilder.Entity<Anuncio>(new AnuncioMapeamento().Configure);
        }
    }
}

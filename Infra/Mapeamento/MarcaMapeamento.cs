using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamento
{
    public class MarcaMapeamento : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();

            builder.HasData(
                new { Id = 1, Nome = "Chevrolet" },
                new { Id = 2, Nome = "Fiat" },
                new { Id = 3, Nome = "Ford" },
                new { Id = 4, Nome = "Honda" });

            builder.ToTable(nameof(Marca));
        }
    }
}

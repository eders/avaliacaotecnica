using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamento
{
    public class AnuncioMapeamento : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorDeCompra).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.ValorDeVenda).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.Cor).IsRequired();
            builder.Property(x => x.TipoDeCombustivel).IsRequired();
            builder.Property(x => x.DataDeVenda).IsRequired(false);
            builder.Property(x => x.ModeloId).IsRequired();

            builder.HasOne(x=>x.Modelo).WithMany().HasForeignKey(x=>x.ModeloId);

            builder.ToTable(nameof(Anuncio));
        }
    }
}

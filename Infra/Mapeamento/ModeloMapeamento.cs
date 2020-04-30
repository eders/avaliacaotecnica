using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapeamento
{
    public class ModeloMapeamento : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Ano).IsRequired();

            builder.HasOne(x => x.Marca).WithMany(x => x.Modelos).HasForeignKey(x => x.MarcaId);

            builder.HasData(
             new { Id = 1, Nome = "Corsa", Ano = "2000", MarcaId = 1 },
             new { Id = 2, Nome = "Corsa", Ano = "2005", MarcaId = 1 },
             new { Id = 3, Nome = "Corsa", Ano = "2009", MarcaId = 1 },
             new { Id = 4, Nome = "Montana", Ano = "2000", MarcaId = 1 },
             new { Id = 5, Nome = "Montana", Ano = "2005", MarcaId = 1 },
             new { Id = 6, Nome = "Montana", Ano = "2009", MarcaId = 1 },
             new { Id = 7, Nome = "Uno", Ano = "2001", MarcaId = 2 },
             new { Id = 8, Nome = "Uno", Ano = "2011", MarcaId = 2 },
             new { Id = 9, Nome = "Uno", Ano = "2015", MarcaId = 2 },
             new { Id = 10, Nome = "Fiorino", Ano = "2001", MarcaId = 2 },
             new { Id = 11, Nome = "Fiorino", Ano = "2015", MarcaId = 2 },
             new { Id = 12, Nome = "Fiorino", Ano = "2016", MarcaId = 2 },
             new { Id = 13, Nome = "Fiesta", Ano = "2001", MarcaId = 3 },
             new { Id = 14, Nome = "Fiesta", Ano = "2005", MarcaId = 3 },
             new { Id = 15, Nome = "Fiesta", Ano = "2007", MarcaId = 3 },
             new { Id = 16, Nome = "Ranger", Ano = "2016", MarcaId = 3 },
             new { Id = 17, Nome = "Ranger", Ano = "2018", MarcaId = 3 },
             new { Id = 18, Nome = "Ranger", Ano = "2019", MarcaId = 3 },
             new { Id = 19, Nome = "Civic", Ano = "2014", MarcaId = 4 },
             new { Id = 20, Nome = "Civic", Ano = "2016", MarcaId = 4 },
             new { Id = 21, Nome = "Civic", Ano = "2018", MarcaId = 4 },
             new { Id = 22, Nome = "CRV", Ano = "2009", MarcaId = 4 },
             new { Id = 23, Nome = "CRV", Ano = "2010", MarcaId = 4 },
             new { Id = 24, Nome = "CRV", Ano = "2019", MarcaId = 4 }
            );

            builder.ToTable(nameof(Modelo));
        }
    }
}

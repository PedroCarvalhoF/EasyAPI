using Api.Domain.Entities.CategoriaPreco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Preco
{
    public class CategoriaPrecoMap : IEntityTypeConfiguration<CategoriaPrecoEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaPrecoEntity> builder)
        {
            builder.ToTable("CategoriasPrecos");
            builder.HasKey(cat => cat.Id);

            builder.HasIndex(cat => cat.DescricaoCategoria);
            builder.Property(cat => cat.DescricaoCategoria)
                   .HasMaxLength(100) // mudei para ver comportamento do banco
                   .IsRequired();
            builder.Property(cat => cat.Habilitado).IsRequired();
        }
    }
}

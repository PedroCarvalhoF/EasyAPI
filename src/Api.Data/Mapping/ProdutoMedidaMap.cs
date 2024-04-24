using Api.Domain.Entities.ProdutoMedida;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    internal class ProdutoMedidaMap : IEntityTypeConfiguration<ProdutoMedidaEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoMedidaEntity> builder)
        {
            builder.ToTable("ProdutoMedidas");
            builder.HasKey(cat => cat.Id);
            builder.HasIndex(cat => cat.Descricao)
                   .IsUnique();

            builder.Property(tipo => tipo.Habilitado)
                .IsRequired();

            builder.Property(cat => cat.Descricao)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}

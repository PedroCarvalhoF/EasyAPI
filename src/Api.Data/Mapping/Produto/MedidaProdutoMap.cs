using Api.Domain.Entities.ProdutoMedida;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Produto
{
    public class MedidaProdutoMap : IEntityTypeConfiguration<ProdutoMedidaEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoMedidaEntity> builder)
        {
            builder.ToTable("ProdutosMedidas");

            builder.HasKey(cat => cat.Id);

            builder.HasIndex(cat => cat.Descricao);

            builder.Property(tipo => tipo.Habilitado)
                .IsRequired();

            builder.Property(cat => cat.Descricao)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}

using Domain.Entities.ProdutoTipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Produto
{
    public class TipoProdutoMap : IEntityTypeConfiguration<ProdutoTipoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoTipoEntity> builder)
        {
            builder.ToTable("TiposProdutos");
            builder.HasKey(tipo => tipo.Id);

            builder.HasIndex(tipo => tipo.DescricaoTipoProduto);

            builder.Property(tipo => tipo.DescricaoTipoProduto)
                   .HasMaxLength(30)
                   .IsRequired();
        }
    }
}

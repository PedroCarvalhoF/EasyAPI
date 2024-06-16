using Api.Domain.Entities.PrecoProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Preco
{
    public class PrecoProdutoMap : IEntityTypeConfiguration<PrecoProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<PrecoProdutoEntity> builder)
        {
            builder.ToTable("PrecosProdutos");
            builder.HasKey(prod => prod.Id);
            builder.Property(prod => prod.ProdutoEntityId)
                   .IsRequired();
            builder.Property(prod => prod.CategoriaPrecoEntityId)
                   .IsRequired();
            builder.Property(prod => prod.PrecoProduto)
                   .IsRequired();
            builder.Property(prod => prod.PrecoProduto).HasColumnType("decimal(18,2)");
            builder.Property(prod => prod.Habilitado)
                   .IsRequired();

            builder.HasOne(preco => preco.ProdutoEntity)
                    .WithMany(produto => produto.PrecoProdutoEntities)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(preco => preco.CategoriaPrecoEntity)
                    .WithMany(cat_preco => cat_preco.PrecoProdutoEntities)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

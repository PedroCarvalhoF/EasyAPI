using Domain.Entities.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    internal class ProdutoMap : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            //tabela Produto
            builder.ToTable("Produtos");
            //Id 
            builder.HasKey(prod => prod.Id);

            //nome do produto
            builder.Property(p => p.NomeProduto)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(p => p.NomeProduto)
                .IsUnique();

            //Codigo de Barras
            builder.Property(p => p.CodigoBarrasPersonalizado)
               .HasMaxLength(100)
               .IsRequired();
            builder.HasIndex(p => p.CodigoBarrasPersonalizado)
                .IsUnique();

            //Descricao
            builder.Property(p => p.Descricao)
              .HasMaxLength(200);

            //Observacoes
            builder.Property(p => p.Observacoes)
              .HasMaxLength(200);

            //categoria do produto
            builder.Property(p => p.CategoriaProdutoEntityId)
                .IsRequired();

            builder.HasOne(p => p.CategoriaProdutoEntity)
                .WithMany(cat => cat.ProdutoEntities)
                .HasForeignKey(prod => prod.CategoriaProdutoEntityId)
                .OnDelete(DeleteBehavior.NoAction);

            //Medida do produto
            builder.Property(p => p.ProdutoMedidaEntityId)
                .IsRequired();

            builder.HasOne(p => p.ProdutoMedidaEntity)
                .WithMany(m => m.ProdutoEntities)
                .HasForeignKey(p => p.ProdutoMedidaEntityId)
                .OnDelete(DeleteBehavior.NoAction);

            //Tipo do Produto
            builder.HasOne(p => p.ProdutoTipoEntity)
               .WithMany(tp => tp.ProdutoEntities)
               .HasForeignKey(p => p.ProdutoTipoEntityId)
               .OnDelete(DeleteBehavior.NoAction);           
        }
    }
}

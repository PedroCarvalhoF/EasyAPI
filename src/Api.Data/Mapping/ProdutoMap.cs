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

            builder.HasData(new ProdutoEntity
            {
                Id = Guid.Parse("f0e75a80-0b64-4b2b-9f53-f3dce3f6d126"),
                Habilitado = true,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                NomeProduto = "Agua sem gas",
                CodigoBarrasPersonalizado = "01",
                Descricao = string.Empty,
                Observacoes = string.Empty,
                CategoriaProdutoEntityId = Guid.Parse("a9b05f16-71f0-4f77-a653-52c1a15b36bc"),
                ProdutoMedidaEntityId = Guid.Parse("414a646f-1146-4b6d-bbfc-39a26e74a091"),
                ProdutoTipoEntityId = Guid.Parse("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                ImgUrl = string.Empty

            });
        }



    }
}

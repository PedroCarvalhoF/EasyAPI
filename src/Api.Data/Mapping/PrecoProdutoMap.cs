using Api.Domain.Entities.PrecoProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PrecoProdutoMap : IEntityTypeConfiguration<PrecoProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<PrecoProdutoEntity> builder)
        {
            builder.ToTable("PrecoProduto");
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

     


            //builder.HasOne(preco => preco.CategoriaPrecoEntity)
            //    .WithMany(categoria => categoria.PrecoProdutoEntities)
            //    .HasForeignKey(preco => preco.CategoriaPrecoEntityId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

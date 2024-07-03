using Easy.Domain.Entities.PDV.PrecoProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class PrecoProdutoMap : IEntityTypeConfiguration<PrecoProdutoEntity>
{
    public void Configure(EntityTypeBuilder<PrecoProdutoEntity> builder)
    {
        builder.ToTable("PrecosProdutos");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

        builder.Property(pr => pr.Preco).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(pr => pr.Produto)
               .WithMany(prod => prod.PrecosProdutos)
               .HasForeignKey(pr => pr.ProdutoEntityId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

        builder.HasOne(pr => pr.CategoriaPreco)
               .WithMany(cat_preco => cat_preco.PrecosProdutos)
               .HasForeignKey(pr => pr.CategoriaPrecoEntityId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
    }
}

using Easy.Domain.Entities.Produto.CategoriaProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class CategoriaProdutoMap : IEntityTypeConfiguration<CategoriaProdutoEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaProdutoEntity> builder)
    {
        builder.ToTable("CategoriasProdutos");

        builder.Property(c => c.DescricaoCategoria).HasMaxLength(60).IsRequired();


        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

    }
}

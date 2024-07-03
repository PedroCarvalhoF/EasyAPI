using Easy.Domain.Entities.PDV.ItensPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedidoEntity>
{
    public void Configure(EntityTypeBuilder<ItemPedidoEntity> builder)
    {
        builder.ToTable("ItensPedidos");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

        builder.Property(item => item.Quantidade).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(item => item.Preco).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(item => item.DescontoItem).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(item => item.SubTotalItem).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(item => item.TotalItem).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(item => item.Cancelado).IsRequired();

        builder.HasOne(item => item.Produto)
            .WithMany(produto => produto.ItensPedido)
            .IsRequired()
            .HasForeignKey(item => item.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(item => item.Pedido)
            .WithMany(pedido => pedido.ItensPedido)
            .IsRequired()
            .HasForeignKey(item => item.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

using Easy.Domain.Entities.PDV.PagamentoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class PagamentoPedidoMap : IEntityTypeConfiguration<PagamentoPedidoEntity>
{
    public void Configure(EntityTypeBuilder<PagamentoPedidoEntity> builder)
    {
        builder.ToTable("PagamentosPedidos");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

        //Forma de pagamento referencia
        builder.HasOne(pgt => pgt.FormaPagamento)
            .WithMany(forma_pg => forma_pg.Pagamentos)
            .IsRequired()
            .HasForeignKey(pgt => pgt.FormaPagamentoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pgt => pgt.Pedido)
            .WithMany(pedido => pedido.Pagamentos)
            .IsRequired()
            .HasForeignKey(pgt => pgt.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(pgt => pgt.ValorPago).IsRequired().HasColumnType("decimal(18,2)");

    }
}

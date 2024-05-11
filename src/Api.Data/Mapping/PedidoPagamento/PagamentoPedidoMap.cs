using Domain.Entities.PagamentoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.PedidoPagamento
{
    public class PagamentoPedidoMap : IEntityTypeConfiguration<PagamentoPedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PagamentoPedidoEntity> builder)
        {
            builder.ToTable("PagamentosPedidos");
            builder.HasKey(pgt => new { pgt.FormaPagamentoEntityId, pgt.PedidoEntityId });

            builder.Property(pgt => pgt.FormaPagamentoEntityId)
                   .IsRequired();
            builder.Property(pgt => pgt.PedidoEntityId)
                  .IsRequired();
            builder.Property(pgt => pgt.ValorPago)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        }
    }
}

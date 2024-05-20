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
            builder.HasKey(pgt => pgt.Id);

            //FormaPagamentoEntityId
            builder.Property(pgt => pgt.FormaPagamentoEntityId)
                   .IsRequired();

            builder.HasOne(pedido => pedido.PedidoEntity)
                    .WithMany(pgt => pgt.PagamentoPedidoEntities)
                    .HasForeignKey(pgt => pgt.FormaPagamentoEntityId)
                    .OnDelete(DeleteBehavior.Restrict);


            //PedidoEntityId
            builder.Property(pgt => pgt.PedidoEntityId)
                  .IsRequired();

            builder.HasOne(pgt => pgt.PedidoEntity)
                    .WithMany(pedido => pedido.PagamentoPedidoEntities)
                    .HasForeignKey(pgt => pgt.PedidoEntityId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pgt => pgt.ValorPago)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        }
    }
}

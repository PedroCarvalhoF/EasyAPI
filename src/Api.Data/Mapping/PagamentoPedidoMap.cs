using Domain.Entities.PagamentoPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PagamentoPedidoMap : IEntityTypeConfiguration<PagamentoPedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PagamentoPedidoEntity> builder)
        {
            builder.ToTable("PagamentoPedido");
            builder.HasKey(pgt => pgt.Id);

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

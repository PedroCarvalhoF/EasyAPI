using Api.Domain.Entities.Pedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(ped => ped.Id);

            builder.Property(ped => ped.NumeroPedido)
                    .IsRequired()
                    .HasMaxLength(255);
            builder.Property(ped => ped.SituacaoPedidoEntityId)
                    .IsRequired();
            builder.Property(ped => ped.UserIdCreatePedido)
                    .IsRequired();
            builder.Property(ped => ped.PontoVendaEntityId)
                    .IsRequired();
            builder.Property(ped => ped.CategoriaPrecoEntityId)
                    .IsRequired();

            builder.Property(ped => ped.TotalItensPedido)
                      .HasColumnType("decimal(18,2)");
            builder.Property(ped => ped.ValorDesconto)
                     .HasColumnType("decimal(18,2)");
            builder.Property(ped => ped.ValorPedido)
                     .HasColumnType("decimal(18,2)");

            builder.HasMany(ped => ped.PagamentoPedidoEntities)
                .WithOne(pgt => pgt.PedidoEntity)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}

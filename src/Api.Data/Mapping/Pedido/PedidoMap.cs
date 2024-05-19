using Api.Domain.Entities.Pedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pedido
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            //tabela
            builder.ToTable("Pedidos");

            //chave primaria
            builder.HasKey(ped => ped.Id);

            //CreateAt
            builder.Property(ped => ped.CreateAt)
                .IsRequired()
                .HasColumnType("datetime");

            //UpdateAt
            builder.Property(ped => ped.UpdateAt)
               .HasColumnType("datetime");

            // Habilitado
            builder.Property(ped => ped.Habilitado)
                .IsRequired();

            // NumeroPedido
            builder.Property(ped => ped.NumeroPedido)
                .IsRequired()
                .HasMaxLength(100);

            // ValorDesconto
            builder.Property(ped => ped.ValorDesconto)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // ValorPedido
            builder.Property(ped => ped.ValorPedido)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Observacoes
            builder.Property(ped => ped.Observacoes)
                .HasMaxLength(100);

            // SituacaoPedidoEntityId
            builder.Property(ped => ped.SituacaoPedidoEntityId)
                .IsRequired();

            builder.HasOne(ped => ped.SituacaoPedidoEntity)
                .WithMany(pedido=>pedido.PedidoEntities)
                .HasForeignKey(ped => ped.SituacaoPedidoEntityId);

            // PontoVendaEntityId
            builder.Property(ped => ped.PontoVendaEntityId)
                .IsRequired();

            builder.HasOne(ped => ped.PontoVendaEntity)
                .WithMany(pdv => pdv.PedidoEntities)
                .HasForeignKey(ped => ped.PontoVendaEntityId)
                .OnDelete(DeleteBehavior.Restrict);

            // CategoriaPrecoEntityId
            builder.Property(ped => ped.CategoriaPrecoEntityId)
                .IsRequired();

            builder.HasOne(ped => ped.CategoriaPrecoEntity)
                .WithMany()
                .HasForeignKey(ped => ped.CategoriaPrecoEntityId).OnDelete(DeleteBehavior.Restrict);

            // UserCreatePedidoId
            builder.Property(ped => ped.UserRegistroId)
                .IsRequired();

            builder.HasOne(ped => ped.UserRegistro)
                .WithMany()
                .HasForeignKey(ped => ped.UserRegistroId).OnDelete(DeleteBehavior.Restrict);
        }


    }
}


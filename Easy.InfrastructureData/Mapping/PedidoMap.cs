using Easy.Domain.Entities.PDV.Pedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class PedidoMap : IEntityTypeConfiguration<PedidoEntity>
{
    public void Configure(EntityTypeBuilder<PedidoEntity> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

        builder.Property(p => p.TipoPedido).IsRequired().HasColumnType("int");
        builder.Property(p => p.NumeroPedido).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Desconto).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.SubTotal).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Total).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Observacoes).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Cancelado).IsRequired();

        //PONTO DE VENDA REFERENCES
        builder.HasOne(p => p.PontoVendaEntity)
            .WithMany(pdv => pdv.Pedidos)
            .HasForeignKey(p => p.PontoVendaEntityId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        //CATEGORIA DE PRECO REFERENCES
        builder.HasOne(p => p.CategoriaPreco)
             .WithMany(cat_preco => cat_preco.Pedidos)
             .HasForeignKey(p => p.CategoriaPrecoId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Restrict);

    }
}

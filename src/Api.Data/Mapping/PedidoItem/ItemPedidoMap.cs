using Domain.Entities.ItensPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.PedidoItem
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedidoEntity>
    {
        public void Configure(EntityTypeBuilder<ItemPedidoEntity> builder)
        {
            //tabela
            builder.ToTable("ItensPedidos");

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

            //ProdutoEntityId
            builder.Property(item => item.ProdutoEntityId)
                .IsRequired();

            builder.HasOne(item => item.ProdutoEntity)
                .WithMany(produto => produto.ItensPedidoEntities)
                .HasForeignKey(item => item.ProdutoEntityId)
                .OnDelete(DeleteBehavior.Restrict);

            //public decimal Quatidade { get; set; }
            builder.Property(item => item.Quatidade)
                .IsRequired()
                .HasColumnType("decimal (18,2)");

            //public decimal Preco { get; set; }
            builder.Property(item => item.Preco)
               .IsRequired()
               .HasColumnType("decimal (18,2)");

            //public decimal SubTotal { get; set; }
            builder.Property(item => item.SubTotal)
              .IsRequired()
              .HasColumnType("decimal (18,2)");

            //public decimal Desconto { get; set; }
            builder.Property(item => item.Desconto)
             .IsRequired()
             .HasColumnType("decimal (18,2)");

            //public decimal Total { get; set; }
            builder.Property(item => item.Total)
            .IsRequired()
            .HasColumnType("decimal (18,2)");

            //public string? ObservacaoItem { get; set; }
            builder.Property(item => item.ObservacaoItem)
                .HasMaxLength(200);

            //public Guid UserId { get; set; }
            builder.Property(item => item.UsuarioPontoVendaEntityId)
               .IsRequired();

            builder.HasOne(item => item.UsuarioPontoVendaEntity)
                .WithMany(user => user.ItemPedidoEntities)
                .HasForeignKey(item => item.UsuarioPontoVendaEntityId)
                .OnDelete(DeleteBehavior.Restrict);


            //public Guid PedidoEntityId { get; set; }
            builder.Property(item => item.PedidoEntityId)
               .IsRequired();

            builder.HasOne(item => item.PedidoEntity)
                .WithMany(pedido => pedido.ItensPedidoEntities)
                .HasForeignKey(item => item.PedidoEntityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

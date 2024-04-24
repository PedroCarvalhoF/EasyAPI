using Domain.Entities.FormaPagamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamentoEntity>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoEntity> builder)
        {
            builder.ToTable("FormaPagamento");
            builder.HasKey(fpg => fpg.Id);
            builder.HasIndex(fpg => fpg.DescricaoFormaPg)
                   .IsUnique();
            builder.Property(cat => cat.DescricaoFormaPg)
                   .HasMaxLength(100)
                   .IsRequired();


            builder.Property(cat => cat.Habilitado)
                   .IsRequired();

            builder.HasMany(forma_pagamento => forma_pagamento.PagamentoPedidoEntities)
                   .WithOne(pagamento_pedido => pagamento_pedido.FormaPagamentoEntity)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

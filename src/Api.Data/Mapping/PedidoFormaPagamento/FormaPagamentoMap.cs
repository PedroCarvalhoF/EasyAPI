using Domain.Entities.FormaPagamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.PedidoFormaPagamento
{
    public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamentoEntity>
    {
        public void Configure(EntityTypeBuilder<FormaPagamentoEntity> builder)
        {
            //FormaPagamentoEntity
            builder.ToTable("FormasPagamentos");
            //Id
            builder.HasKey(fpg => fpg.Id);

            //DescricaoFormaPg
            builder.HasIndex(fpg => fpg.DescricaoFormaPg);
                  
            builder.Property(fpg => fpg.DescricaoFormaPg)
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(fpg => fpg.Habilitado)
                   .IsRequired();
        }
    }
}

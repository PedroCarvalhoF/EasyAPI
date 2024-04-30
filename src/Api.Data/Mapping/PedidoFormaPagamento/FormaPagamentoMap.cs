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
            builder.HasIndex(fpg => fpg.DescricaoFormaPg)
                   .IsUnique();
            builder.Property(fpg => fpg.DescricaoFormaPg)
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(fpg => fpg.Habilitado)
                   .IsRequired();

            builder.HasData(new FormaPagamentoEntity
            {
                CreateAt = DateTime.Now,
                DescricaoFormaPg = "Dinheiro",
                Habilitado = true,
                Id = Guid.Parse("92008957-f185-4563-9d9e-7b71f4ea2691"),
                UpdateAt = DateTime.Now
            });


        }
    }
}

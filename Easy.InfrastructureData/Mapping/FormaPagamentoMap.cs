using Easy.Domain.Entities.PDV.FormaPagamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamentoEntity>
{
    public void Configure(EntityTypeBuilder<FormaPagamentoEntity> builder)
    {
        builder.ToTable("FormasPagamentos");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();


        builder.Property(f => f.DescricaFormaPagamento).IsRequired().HasMaxLength(50);
        builder.Property(f => f.Codigo).IsRequired();
    }
}

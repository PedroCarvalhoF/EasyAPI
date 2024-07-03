using Easy.Domain.Entities.PDV.Periodo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class PeriodoPdvMap : IEntityTypeConfiguration<PeriodoPdvEntity>
{
    public void Configure(EntityTypeBuilder<PeriodoPdvEntity> builder)
    {
        builder.ToTable("PeriodosPdvs");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

        builder.Property(p => p.DescricaoPeriodo).IsRequired().HasMaxLength(50);
    }
}

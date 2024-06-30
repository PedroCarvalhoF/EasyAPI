using Easy.Domain.Entities.PDV.PDV;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class PontoVendaMap : IEntityTypeConfiguration<PontoVendaEntity>
{
    public void Configure(EntityTypeBuilder<PontoVendaEntity> builder)
    {
        builder.ToTable("PontosVendas");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

        builder.Property(pdv => pdv.Aberto).IsRequired();

        builder.HasOne(pdv => pdv.PeriodoPdv)
            .WithMany(per => per.PontosVendas)
            .HasForeignKey(pdv => pdv.PeriodoPdvId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pdv => pdv.UsuarioGerentePdv)
            .WithMany(userPdv => userPdv.UsuariosGerentesPdvs)
            .HasForeignKey(pdv => pdv.UsuarioGerentePdvId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pdv => pdv.UsuarioPdv)
            .WithMany(usersPdv => usersPdv.UsuariosPdvs)
            .HasForeignKey(pdv => pdv.UsuarioPdvId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

    }
}

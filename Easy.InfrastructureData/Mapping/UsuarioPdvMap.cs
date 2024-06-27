using Easy.Domain.Entities.PDV.UserPDV;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class UsuarioPdvMap : IEntityTypeConfiguration<UsuarioPdvEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioPdvEntity> builder)
    {
        builder.ToTable("UsuariosPdvs");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();

        builder.HasOne(updv => updv.UserPdv)
               .WithOne(user => user.UsuarioPdv)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
    }
}

using Domain.Entities.PontoVendaUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.PontoVendaUser
{
    public class UsuarioPontoVendaMap : IEntityTypeConfiguration<UsuarioPontoVendaEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioPontoVendaEntity> builder)
        {
            //tabela
            builder.ToTable("UsuariosPontoVendas");

            //chave primaria
            builder.HasKey(ped => ped.UserId);

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

            //UserId
            builder.Property(u => u.UserId).IsRequired();
            builder.HasIndex(u => u.UserId).IsUnique();

            builder.HasOne(updv => updv.UserPdv)
                .WithOne(updv => updv.UsuarioPontoVendaEntity);

        }
    }
}

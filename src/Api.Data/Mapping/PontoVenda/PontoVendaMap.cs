using Api.Domain.Entities.PontoVenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Data.Mapping.PontoVena
{
    public class PontoVendaMap : IEntityTypeConfiguration<PontoVendaEntity>
    {
        public void Configure(EntityTypeBuilder<PontoVendaEntity> builder)
        {
            //tabela PDV - PontoVendaEntity
            builder.ToTable("PontosVendas");
            //Id 
            builder.HasKey(pdv => pdv.Id);

            //PeriodoPontoVendaEntity
            builder.Property(pdv => pdv.PeriodoPontoVendaEntityId)
                .IsRequired();

            //AbertoFechado
            builder.Property(pdv => pdv.AbertoFechado)
                .IsRequired();


            //PerfilUsuarioEntityAbrilPDV
            builder.Property(p => p.UserPdvCreateId)
                .IsRequired();

            builder.HasOne(pdv => pdv.UserPdvCreate)
                .WithMany(perfil => perfil.UserPontoVendaCreate)
                .HasForeignKey(pdv => pdv.UserPdvCreateId)
                .OnDelete(DeleteBehavior.Restrict);


            //PerfilUsuarioEntityUtilizarPDV
            builder.Property(pdv => pdv.UserPdvUsingId)
                .IsRequired();
            builder.HasOne(pdv => pdv.UserPdvUsing)
                .WithMany(perfil => perfil.UserPontoVendaUsing)
                .HasForeignKey(pdv => pdv.UserPdvUsingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

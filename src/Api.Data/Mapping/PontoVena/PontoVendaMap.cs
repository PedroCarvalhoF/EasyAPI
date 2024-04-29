using Api.Domain.Entities.PontoVenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            //PerfilUsuarioEntityAbrilPDV
            builder.Property(p => p.IdPerfilAbriuPDV)
                .IsRequired();

            builder.HasOne(pdv => pdv.PerfilUsuarioEntityAbrilPDV)
                .WithMany(perfil => perfil.PontoVendaEntitiesAbriu)
                .HasForeignKey(pdv => pdv.IdPerfilAbriuPDV)
                .OnDelete(DeleteBehavior.NoAction);


            //PerfilUsuarioEntityUtilizarPDV
            builder.Property(pdv => pdv.IdPerfilUtilizarPDV)
                .IsRequired();
            builder.HasOne(pdv => pdv.PerfilUsuarioEntityUtilizarPDV)
                .WithMany(perfil => perfil.PontoVendaEntitiesUtilizar)
                .HasForeignKey(pdv => pdv.IdPerfilUtilizarPDV)
                .OnDelete(DeleteBehavior.NoAction);

            //PeriodoPontoVendaEntity
            builder.Property(pdv => pdv.PeriodoPontoVendaEntityId)
                .IsRequired();

            //AbertoFechado
            builder.Property(pdv => pdv.AbertoFechado)
                .IsRequired();
        }
    }
}

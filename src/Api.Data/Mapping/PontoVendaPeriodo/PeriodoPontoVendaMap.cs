using Domain.Entities.PontoVendaPeriodoVenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.PontoVendaPeriodo
{
    public class PeriodoPontoVendaMap : IEntityTypeConfiguration<PeriodoPontoVendaEntity>
    {
        public void Configure(EntityTypeBuilder<PeriodoPontoVendaEntity> builder)
        {
            //tabela
            builder.ToTable("PeriodosPontosVendas");

            //chave primaria
            builder.HasKey(pr => pr.Id);

            //CreateAt
            builder.Property(pr => pr.CreateAt)
                .IsRequired()
                .HasColumnType("datetime");

            //UpdateAt
            builder.Property(pr => pr.UpdateAt)
               .HasColumnType("datetime");

            // Habilitado
            builder.Property(pr => pr.Habilitado)
                .IsRequired();

            builder.HasIndex(tipo => tipo.DescricaoPeriodo)
                   .IsUnique();
            builder.Property(tipo => tipo.DescricaoPeriodo)
                   .HasMaxLength(100)
                   .IsRequired();


            //builder.HasData(new PeriodoPontoVendaEntity
            //{
            //    Id = Guid.Parse("567906bb-6eb4-42e9-b890-10e6da214766"),
            //    CreateAt = DateTime.Now,
            //    DescricaoPeriodo = "Almoço",
            //    Habilitado = true,
            //    UpdateAt = DateTime.Now
            //},
            //new PeriodoPontoVendaEntity
            //{
            //    Id = Guid.Parse("fc6a5d67-8356-4270-b9e6-7749b553dcf3"),
            //    CreateAt = DateTime.Now,
            //    DescricaoPeriodo = "Janta",
            //    Habilitado = true,
            //    UpdateAt = DateTime.Now
            //},
            //new PeriodoPontoVendaEntity
            //{
            //    Id = Guid.Parse("f14c83df-1fa4-4a83-8070-b16ecb19aa77"),
            //    CreateAt = DateTime.Now,
            //    DescricaoPeriodo = "Dia Todo",
            //    Habilitado = true,
            //    UpdateAt = DateTime.Now
            //},
            //new PeriodoPontoVendaEntity
            //{
            //    Id = Guid.Parse("7e107de8-c97a-435b-9976-7a689ca28bb7"),
            //    CreateAt = DateTime.Now,
            //    DescricaoPeriodo = "Noturno",
            //    Habilitado = true,
            //    UpdateAt = DateTime.Now
            //}
            //);
        }
    }
}

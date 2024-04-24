using Domain.Entities.Pessoa.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(ps => ps.Id);

            builder.HasIndex(ps => ps.PrimeiroNome)
                .IsUnique();

            builder.Property(ps => ps.PrimeiroNome)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(ps => ps.CpfCnpj)
               .IsUnique();

            builder.Property(ps => ps.CpfCnpj)
              .IsRequired()
              .HasMaxLength(14);

            builder.HasIndex(ps => ps.RgIE)
               .IsUnique();
            builder.Property(ps => ps.RgIE)
             .IsRequired()
             .HasMaxLength(14);




            builder.HasIndex(ps => ps.SegundoNome)
                .IsUnique();
            builder.Property(ps => ps.SegundoNome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ps => ps.Sexo)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(ps => ps.DataNascimentoFundacao)
                .IsRequired();

            builder.HasOne(ps => ps.PessoaTipoEntity)
                    .WithMany(pt => pt.PessoaEntities)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

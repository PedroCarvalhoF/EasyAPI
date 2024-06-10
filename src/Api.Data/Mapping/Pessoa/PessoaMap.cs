using Domain.Entities.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pessoa
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoas");
            builder.HasKey(ps => ps.Id);

            //NomeNomeFantasia                
            builder.Property(ps => ps.NomeNomeFantasia).IsRequired().HasMaxLength(50);

            //SobreNomeRazaoSocial 
            builder.Property(ps => ps.SobreNomeRazaoSocial).IsRequired().HasMaxLength(100);

            //CpfCnpj
            builder.HasIndex(ps => ps.CpfCnpj).IsUnique();
            builder.Property(ps => ps.CpfCnpj).IsRequired().HasMaxLength(50);

            //RgIE
            builder.HasIndex(ps => ps.RgIE).IsUnique();
            builder.Property(ps => ps.RgIE).IsRequired().HasMaxLength(50);

            //PessoaTipo
            builder.Property(ps => ps.PessoaTipo).IsRequired().HasMaxLength(50);



        }
    }
}

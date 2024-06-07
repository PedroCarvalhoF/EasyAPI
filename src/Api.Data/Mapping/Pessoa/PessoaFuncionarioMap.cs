using Domain.Entities.Pessoa.PessoaFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pessoa
{
    public class PessoaFuncionarioMap : IEntityTypeConfiguration<PessoaFuncionarioEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaFuncionarioEntity> builder)
        {
            builder.ToTable("PessoasFuncionario");
            builder.HasKey(pfunc => pfunc.PessoaEntityId);

            builder.HasOne(pFunc => pFunc.PessoaEntity)
                .WithOne(pessoa => pessoa.PessoaFuncionarioEntity)
                .HasForeignKey<PessoaFuncionarioEntity>(p => p.PessoaEntityId);
        }
    }
}

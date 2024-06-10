using Domain.Entities.Pessoa.Funcionario.Funcao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pessoa.Funcionario.Funcao
{
    public class FuncaoFuncionarioMap : IEntityTypeConfiguration<FuncaoFuncionarioEntity>
    {
        public void Configure(EntityTypeBuilder<FuncaoFuncionarioEntity> builder)
        {
            builder.ToTable("FuncoesFuncionarios");
            builder.HasKey(f => f.Id);
        }
    }
}

using Domain.Entities.Pessoa.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pessoa
{
    public class PessoaDadosBancariosMap : IEntityTypeConfiguration<PessoaDadosBancariosEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaDadosBancariosEntity> builder)
        {
            builder.ToTable("PessoaDadosBancarios");
        }
    }
}

using Domain.Entities.Pessoa.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pessoa
{
    public class DadosBancariosMap : IEntityTypeConfiguration<DadosBancariosEntity>
    {
        public void Configure(EntityTypeBuilder<DadosBancariosEntity> builder)
        {
            builder.ToTable("PessoaDadosBancarios");
        }
    }
}

using Domain.Entities.Pessoa.Funcionario.CTPS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.Pessoa.Funcionario.CTPS
{
    public class CtpsMap : IEntityTypeConfiguration<CtpsEntity>
    {
        public void Configure(EntityTypeBuilder<CtpsEntity> builder)
        {
            builder.ToTable("Ctpss");
            builder.HasKey(ct => ct.Id);
        }
    }
}

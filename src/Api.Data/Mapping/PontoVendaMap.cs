using Api.Domain.Entities.PontoVenda;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PontoVendaMap : IEntityTypeConfiguration<PontoVendaEntity>
    {
        public void Configure(EntityTypeBuilder<PontoVendaEntity> builder)
        {
        }
    }
}

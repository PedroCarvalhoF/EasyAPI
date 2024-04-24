using Api.Domain.Entities.Pessoa.PessoaTipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class PessoaTipoMap : IEntityTypeConfiguration<PessoaTipoEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaTipoEntity> builder)
        {
            builder.ToTable("PessoaTipo");
            builder.HasKey(pt => pt.Id);
            builder.HasIndex(pt => pt.DescricaoPessoaTipo)
                   .IsUnique();
            builder.Property(pt => pt.DescricaoPessoaTipo)
                  .HasMaxLength(100)
                  .IsRequired();



            builder.HasMany(pt => pt.PessoaEntities)
                    .WithOne(pt => pt.PessoaTipoEntity)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

using Domain.Entities.ProdutoTipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ProdutoTipoMap : IEntityTypeConfiguration<ProdutoTipoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoTipoEntity> builder)
        {
            builder.ToTable("TiposProdutos");
            builder.HasKey(tipo => tipo.Id);

            builder.HasIndex(tipo => tipo.DescricaoTipoProduto)
                   .IsUnique();

            builder.Property(tipo => tipo.DescricaoTipoProduto)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.HasData(new ProdutoTipoEntity
            {
                CreateAt = DateTime.UtcNow,
                DescricaoTipoProduto = "Venda",
                Habilitado = true,
                Id = Guid.Parse("edddccfa-a4af-4831-b9ee-29bdd5f755af"),
                UpdateAt = DateTime.UtcNow,
            }, new ProdutoTipoEntity
            {
                CreateAt = DateTime.UtcNow,
                DescricaoTipoProduto = "Materia Prima",
                Habilitado = true,
                Id = Guid.Parse("1e11b25a-8bf5-4d57-80b7-396d09cbfcf1"),
                UpdateAt = DateTime.UtcNow,
            });
        }
    }
}

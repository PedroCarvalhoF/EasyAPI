using Domain.Entities.CategoriaProduto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CategoriaProdutoMap : IEntityTypeConfiguration<CategoriaProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaProdutoEntity> builder)
        {
            builder.ToTable("CategoriasProdutos");
            builder.HasKey(cat => cat.Id);
            builder.HasIndex(cat => cat.DescricaoCategoria)
                   .IsUnique();
            builder.Property(cat => cat.DescricaoCategoria)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(cat => cat.Habilitado).IsRequired();
        }
    }
}

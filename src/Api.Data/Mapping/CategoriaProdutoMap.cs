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
                   .HasMaxLength(80)
                   .IsRequired();
            builder.Property(cat => cat.Habilitado).IsRequired();


            builder.HasData(new CategoriaProdutoEntity
            {
                UpdateAt = DateTime.UtcNow,
                CreateAt= DateTime.UtcNow,
                DescricaoCategoria ="Executivos",
                Habilitado= true    ,
                Id = Guid.Parse("a9b05f16-71f0-4f77-a653-52c1a15b36bc")
            },
            new CategoriaProdutoEntity
            {
                UpdateAt = DateTime.UtcNow,
                CreateAt = DateTime.UtcNow,
                DescricaoCategoria = "Bebidas",
                Habilitado = true,
                Id = Guid.Parse("d9d229c4-9a64-4836-af41-2f111f229c46")
            });
        }
    }
}

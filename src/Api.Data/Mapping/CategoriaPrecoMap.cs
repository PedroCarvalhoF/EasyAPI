using Api.Domain.Entities.CategoriaPreco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CategoriaPrecoMap : IEntityTypeConfiguration<CategoriaPrecoEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaPrecoEntity> builder)
        {
            builder.ToTable("CategoriasPrecos");
            builder.HasKey(cat => cat.Id);

            builder.HasIndex(cat => cat.DescricaoCategoria)
                   .IsUnique();
            builder.Property(cat => cat.DescricaoCategoria)
                   .HasMaxLength(100) // mudei para ver comportamento do banco
                   .IsRequired();
            builder.Property(cat => cat.Habilitado).IsRequired();


            //builder.HasData(new CategoriaPrecoEntity
            //{
            //    DescricaoCategoria = "Balcão",
            //    CreateAt = DateTime.Now,
            //    Habilitado = true,
            //    Id = Guid.Parse("710bd8dd-1853-43a1-8708-ca1f259d71ad"),
            //    UpdateAt = DateTime.Now
            //},
            //new CategoriaPrecoEntity
            //{
            //    DescricaoCategoria = "IFood",
            //    CreateAt = DateTime.Now,
            //    Habilitado = true,
            //    Id = Guid.Parse("5533b87c-72d5-4033-85c4-ae44f5a3210c"),
            //    UpdateAt = DateTime.Now
            //},
            //new CategoriaPrecoEntity
            //{
            //    DescricaoCategoria = "Lojista",
            //    CreateAt = DateTime.Now,
            //    Habilitado = true,
            //    Id = Guid.Parse("ed65a4e3-a0b0-40a7-b7ae-3397a965d924"),
            //    UpdateAt = DateTime.Now
            //});
        }
    }
}

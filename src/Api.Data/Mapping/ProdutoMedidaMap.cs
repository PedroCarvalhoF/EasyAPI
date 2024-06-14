using Api.Domain.Entities.ProdutoMedida;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ProdutoMedidaMap : IEntityTypeConfiguration<ProdutoMedidaEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoMedidaEntity> builder)
        {
            builder.ToTable("ProdutosMedidas");
            builder.HasKey(cat => cat.Id);
            builder.HasIndex(cat => cat.Descricao)
                   .IsUnique();

            builder.Property(tipo => tipo.Habilitado)
                .IsRequired();

            builder.Property(cat => cat.Descricao)
                   .HasMaxLength(50)
                   .IsRequired();

            //builder.HasData(new ProdutoMedidaEntity
            //{
            //    UpdateAt = DateTime.UtcNow,
            //    CreateAt = DateTime.UtcNow,
            //    Descricao = "Unidade",
            //    Habilitado = true,
            //    Id = Guid.Parse("414a646f-1146-4b6d-bbfc-39a26e74a091")
            //},
            //new ProdutoMedidaEntity
            //{
            //    UpdateAt = DateTime.UtcNow,
            //    CreateAt = DateTime.UtcNow,
            //    Descricao = "Caixa",
            //    Habilitado = true,
            //    Id = Guid.Parse("2f943e86-f06f-4f7d-babf-48d0d2d8f3ac")
            //});
        }
    }
}

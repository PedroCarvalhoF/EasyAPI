using Easy.Domain.Entities.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping
{
    public class CategoriaProdutoMap : IEntityTypeConfiguration<CategoriaProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaProdutoEntity> builder)
        {
            builder.ToTable("CategoriasProdutos");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.DescricaoCategoria).HasMaxLength(60).IsRequired();

            builder.Property(bs => bs.CreateAt).HasColumnType("datetime").IsRequired();
            builder.Property(bs => bs.UpdateAt).HasColumnType("datetime");
            builder.Property(bs => bs.Habilitado).IsRequired();
        }
    }
}

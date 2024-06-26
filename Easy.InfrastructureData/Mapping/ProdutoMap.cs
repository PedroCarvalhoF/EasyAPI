using Easy.Domain.Entities.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
            builder.Property(b => b.UpdateAt).HasColumnType("datetime");
            builder.Property(b => b.Habilitado).IsRequired();

            builder.Property(p => p.NomeProduto).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(p => p.Descricao).HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(p => p.Observacoes).HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(p => p.MedidaProdutoEnum).IsRequired().HasColumnType("int");
            builder.Property(p => p.TipoProdutoEnum).IsRequired().HasColumnType("int");

            builder.HasOne(p => p.CategoriaProdutoEntity)
                   .WithMany(cat => cat.Produtos)
                   .HasForeignKey(p => p.CategoriaProdutoEntityId).IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

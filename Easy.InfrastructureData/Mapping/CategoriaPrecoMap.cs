using Easy.Domain.Entities.PDV.CategoriaPreco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easy.InfrastructureData.Mapping;

public class CategoriaPrecoMap : IEntityTypeConfiguration<CategoriaPrecoEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaPrecoEntity> builder)
    {
        builder.ToTable("CategoriasPrecos");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.UserMasterClienteIdentityId).IsRequired();
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.CreateAt).HasColumnType("datetime").IsRequired();
        builder.Property(b => b.UpdateAt).HasColumnType("datetime");
        builder.Property(b => b.Habilitado).IsRequired();


        builder.Property(f => f.DescricaoCategoriaPreco).IsRequired().HasMaxLength(50);
        builder.Property(f => f.Codigo).IsRequired();
    }
}

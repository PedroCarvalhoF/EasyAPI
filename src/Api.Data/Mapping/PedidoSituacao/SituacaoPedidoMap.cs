using Domain.Entities.PedidoSituacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping.PedidoSituacao
{
    public class SituacaoPedidoMap : IEntityTypeConfiguration<SituacaoPedidoEntity>
    {
        public void Configure(EntityTypeBuilder<SituacaoPedidoEntity> builder)
        {
            //tabela Produto
            builder.ToTable("SituacoesPedidos");
            //Id 
            builder.HasKey(prod => prod.Id);

            //Descricao
            builder.Property(p => p.DescricaoSituacao)
                .HasMaxLength(80)
                .IsRequired();
            builder.HasIndex(p => p.DescricaoSituacao)
                .IsUnique();

            builder.HasData(new SituacaoPedidoEntity
            {
                Id = Guid.Parse("abc0f0f9-3295-439c-a468-795b071b7f22"),
                DescricaoSituacao = "Aberto",
                CreateAt = DateTime.Now,
                Habilitado = true,
                UpdateAt = DateTime.Now
            },
            new SituacaoPedidoEntity
            {
                Id = Guid.Parse("185b07da-7e82-43d1-b61f-912d8b29a34c"),
                DescricaoSituacao = "Fechado",
                CreateAt = DateTime.Now,
                Habilitado = true,
                UpdateAt = DateTime.Now
            },
            new SituacaoPedidoEntity
            {
                Id = Guid.Parse("11b17cc5-c8b1-48f9-b9fd-886339441328"),
                DescricaoSituacao = "Cancelado",
                CreateAt = DateTime.Now,
                Habilitado = true,
                UpdateAt = DateTime.Now
            });
        }
    }
}

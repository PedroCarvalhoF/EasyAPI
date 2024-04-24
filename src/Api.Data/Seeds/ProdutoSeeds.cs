using Domain.Entities.Produto;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeds
{
    public static class ProdutoSeeds
    {
        public static void Produto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoEntity>().HasData(
                new ProdutoEntity
                {
                    CategoriaProdutoEntityId = Guid.Parse("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
                    CodigoBarrasPersonalizado = "agua",
                    CreateAt = DateTime.Now,
                    Descricao = "agua zero sódio",
                    Habilitado = true,
                    Id = Guid.Parse("d2a0c172-e742-4e54-a806-938ddaaf8edb"),
                    ImgUrl = "agua.jpg",
                    ProdutoMedidaEntityId = Guid.Parse("05b3382d-0940-446a-8c2c-3e27293cf77d"),
                    NomeProduto = "Agua sem Gás",
                    Observacoes = "Vendida com ou sem gelo",
                    ProdutoTipoEntityId = Guid.Parse("59de4011-1ca7-4a52-833c-9672a03320ac"),
                    UpdateAt = DateTime.Now
                });
        }
    }
}

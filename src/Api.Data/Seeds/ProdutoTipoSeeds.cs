using Domain.Entities.Produto;
using Domain.Entities.ProdutoTipo;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeds
{
    public static class ProdutoTipoSeeds
    {
        public static void TipoProdutoSeeds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoTipoEntity>().HasData(
                new ProdutoTipoEntity
                {
                    Id = Guid.Parse("2491c7e2-10ec-48a4-8898-44e24814f23d"),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Habilitado = true,
                    DescricaoTipoProduto = "Venda",
                },
                 new ProdutoTipoEntity
                 {
                     Id = Guid.Parse("3cca7caf-8a98-40b2-9f20-3f864f59e1c5"),
                     CreateAt = DateTime.Now,
                     UpdateAt = DateTime.Now,
                     Habilitado = true,
                     DescricaoTipoProduto = "Materia Prima",
                 },
                  new ProdutoTipoEntity
                  {
                      Id = Guid.Parse("59de4011-1ca7-4a52-833c-9672a03320ac"),
                      CreateAt = DateTime.Now,
                      UpdateAt = DateTime.Now,
                      Habilitado = true,
                      DescricaoTipoProduto = "Ambos",
                  });
        }
    }
}

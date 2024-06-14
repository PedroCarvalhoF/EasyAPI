using Domain.Entities.CategoriaProduto;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeds
{
    public static class CategoriaProdutoSeeds
    {
        public static void CategoriaProduto(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CategoriaProdutoEntity>().HasData(
            //    new CategoriaProdutoEntity
            //    {
            //        CreateAt = DateTime.Now,
            //        DescricaoCategoria = "Bebidas",
            //        Id = Guid.Parse("6fb282e9-6ee8-44d9-a049-994f68bd0b27"),
            //        Habilitado = true

            //    },
            //      new CategoriaProdutoEntity
            //      {
            //          CreateAt = DateTime.Now,
            //          DescricaoCategoria = "Promoções",
            //          Id = Guid.NewGuid(),
            //          Habilitado = true

            //      },
            //        new CategoriaProdutoEntity
            //        {
            //            CreateAt = DateTime.Now,
            //            DescricaoCategoria = "Executivos",
            //            Id = Guid.NewGuid(),
            //            Habilitado = true

            //        });
        }
    }
}

using Api.Domain.Entities.ProdutoMedida;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeds
{
    public class ProdutoMedidaSeeds
    {
        public static void MedidaDoProdutoSeeds(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProdutoMedidaEntity>().HasData(
            //    new ProdutoMedidaEntity
            //    {
            //        Id = Guid.Parse("cc8119c5-7651-4708-bba4-8f350726bdac"),
            //        CreateAt = DateTime.Now,
            //        UpdateAt = DateTime.Now,
            //        Descricao = "Litro",
            //        Habilitado = true,
            //    },
            //    new ProdutoMedidaEntity
            //    {
            //        Id = Guid.Parse("9bbe9cc9-ba40-4bb3-9b71-74a8234133a5"),
            //        CreateAt = DateTime.Now,
            //        UpdateAt = DateTime.Now,
            //        Descricao = "Caixa",
            //        Habilitado = true,
            //    },
            //    new ProdutoMedidaEntity
            //    {
            //        Id = Guid.Parse("05b3382d-0940-446a-8c2c-3e27293cf77d"),
            //        CreateAt = DateTime.Now,
            //        UpdateAt = DateTime.Now,
            //        Descricao = "Unidade",
            //        Habilitado = true,
            //    });
        }
    }
}

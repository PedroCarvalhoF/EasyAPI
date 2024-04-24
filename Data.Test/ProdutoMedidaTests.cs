using Api.Data.Context;
using Api.Domain.Entities.ProdutoMedida;
using Data.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test
{
    public class ProdutoMedidaTests : BaseTest, IClassFixture<DtTeste>
    {
        private IServiceProvider _serviceProvider;
        public ProdutoMedidaTests(DtTeste dtTeste)
        {
            _serviceProvider = dtTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD PRODUTO MEDIDA")]
        [Trait("CRUD", "MedidaProduto")]
        public async Task E_POSSIVEL_REALIZAR_TESTE_MEDIDAS_DO_PRODUTO()
        {
            using (MyContext? context = _serviceProvider.GetService<MyContext>())
            {                //MEDIDA DO PRODUTO
                ProdutoMedidaImplementacao _produtoMedidaImplementacao = new ProdutoMedidaImplementacao(context);
                ProdutoMedidaEntity produtoMedidaEntity = new ProdutoMedidaEntity
                {
                    CreateAt = DateTime.Now,
                    Descricao = "PESO",
                    Id = Guid.Parse("b7969f12-597e-42bf-a545-f1d81fef103b")
                };

                ProdutoMedidaEntity produtoMedidaResult = await _produtoMedidaImplementacao.InsertAsync(produtoMedidaEntity);
                Assert.NotNull(produtoMedidaResult);
                Assert.Equal("PESO", produtoMedidaResult.Descricao);
                Assert.False(produtoMedidaResult.Id == Guid.Empty);
                Assert.True(produtoMedidaResult != null);
                Assert.True(produtoMedidaResult.Id != Guid.Parse("b7969f12-597e-42bf-a545-f1d81fef103b"));

                ProdutoMedidaEntity produtoMedidaEntity2 = new ProdutoMedidaEntity
                {
                    CreateAt = DateTime.Now,
                    Descricao = "PESO2",
                    Id = Guid.Parse("b7969f12-597e-42bf-a545-f1d81fef103b")
                };
                ProdutoMedidaEntity produtoMedidaResult2 = await _produtoMedidaImplementacao.InsertAsync(produtoMedidaEntity2);

                ProdutoMedidaEntity produtoMedidaEntity3 = new ProdutoMedidaEntity
                {
                    CreateAt = DateTime.Now,
                    Descricao = "PESO3",
                    Id = Guid.Parse("b7969f12-597e-42bf-a545-f1d81fef103b")
                };
                ProdutoMedidaEntity produtoMedidaResult3 = await _produtoMedidaImplementacao.InsertAsync(produtoMedidaEntity3);
                ProdutoMedidaEntity produtoMedidaEntity4 = new ProdutoMedidaEntity
                {
                    CreateAt = DateTime.Now,
                    Descricao = "PESO4",
                    Id = Guid.Parse("b7969f12-597e-42bf-a545-f1d81fef103b")
                };
                ProdutoMedidaEntity produtoMedidaResult4 = await _produtoMedidaImplementacao.InsertAsync(produtoMedidaEntity4);


                IEnumerable<ProdutoMedidaEntity> entities = await _produtoMedidaImplementacao.SelectAsync();
                Assert.True(entities.Any());
                Assert.True(entities.Count() == 4);
                Assert.False(entities == null);


                ProdutoMedidaEntity? getProdutoMedida4 = entities.FirstOrDefault(m => m.Descricao.Equals("PESO4"));
                Assert.NotNull(getProdutoMedida4);

                IEnumerable<ProdutoMedidaEntity> result2 = await _produtoMedidaImplementacao.Get("PESO");
                Assert.NotNull(result2);
                Assert.True(result2.Count() >= 4);


                IEnumerable<ProdutoMedidaEntity> result3 = await _produtoMedidaImplementacao.Get("PESO4");
                Assert.NotNull(result2);
                Assert.True(result3.Count() == 1);

                ProdutoMedidaEntity result4 = await _produtoMedidaImplementacao.SelectAsync(result3.First().Id);
                Assert.NotNull(result4);

                result4.Descricao = "PESO_UPDATE";
                ProdutoMedidaEntity resultUpdate = await _produtoMedidaImplementacao.UpdateAsync(result4);

                Assert.NotNull(resultUpdate);
                Assert.True(resultUpdate.Descricao == result4.Descricao);
            }
        }
    }
}

using Api.Data.Context;
using Data.Implementations;
using Domain.Entities.FormaPagamento;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test
{
    public class FormaPagamentoCrudCompleto : BaseTest, IClassFixture<DtTeste>
    {
        private IServiceProvider _serviceProvider;

        public FormaPagamentoCrudCompleto(DtTeste dtTeste)
        {
            _serviceProvider = dtTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD DE FORMA PAGAMENTO")]
        [Trait("CRUD", "FormaPagamentoEntity")]
        public async Task E_POSSIVEL_REALIZAR_CRUD_CATEGORIA()
        {
            using (MyContext? context = _serviceProvider.GetService<MyContext>())
            {
                FormaPagamentoImplementacao _repositorio = new FormaPagamentoImplementacao(context);

                FormaPagamentoEntity _entity = new FormaPagamentoEntity
                {
                    CreateAt = DateTime.Now,
                    DescricaoFormaPg = Faker.Name.First(),
                    Habilitado = true,
                    Id = Guid.NewGuid(),
                    ////PagamentoPedidoEntity = null  -- corrigir
                };

                FormaPagamentoEntity result = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(result);
                Assert.Equal(_entity.DescricaoFormaPg, result.DescricaoFormaPg);
                Assert.False(result.Id == Guid.Empty);
                Assert.True(result != null);
            }
        }
    }
}

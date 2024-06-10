using Api.Data.Context;
using Data.Implementations.Pessoa.Funcionario.CTPS;
using Domain.Entities.Pessoa.Funcionario.CTPS;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test.Pessoa.Funcionario.CTPS
{
    public class CtpsTesteCRUD : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public CtpsTesteCRUD(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }


        [Fact(DisplayName = "CRUD de CTPS")]
        [Trait("CRUD", "CtpsEntity")]
        public async Task E_Possivel_Realizar_CRUD_CTPS()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                var _repository = new CtpsImplementacao(context);

                var ctps1 = new CtpsEntity
                {
                    CreateAt = DateTime.Now,
                    Digito = "1",
                    Habilitado = true,
                    Id = Guid.NewGuid(),
                    NumeroCTPS = "11111",
                    NumeroPIS = "11111",
                    Serie = "1111",
                    UpdateAt = DateTime.Now
                };

                var result1 = await _repository.InsertAsync(ctps1);
                Assert.NotNull(result1);

                var ctps2 = new CtpsEntity
                {
                    CreateAt = DateTime.Now,
                    Digito = "2",
                    Habilitado = true,
                    Id = Guid.NewGuid(),
                    NumeroCTPS = "2222",
                    NumeroPIS = "2222",
                    Serie = "2222",
                    UpdateAt = DateTime.Now
                };

                var result2 = await _repository.InsertAsync(ctps2);
                Assert.NotNull(result2);

                var entities = await _repository.SelectAsync();
                Assert.True(entities.Count() == 2);

                await _repository.DeleteAsync(result1.Id);
                await _repository.DeleteAsync(result2.Id);

                var entities2 = await _repository.SelectAsync();
                Assert.True(entities2.Count() ==0);
            }
        }
    }
}

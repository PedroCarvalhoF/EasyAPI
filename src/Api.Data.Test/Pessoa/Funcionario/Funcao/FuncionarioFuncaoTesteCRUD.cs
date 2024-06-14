using Api.Data.Context;
using Data.Implementations.Pessoa.Funcionario.Funcao;
using Domain.Entities.Pessoa.Funcionario.Funcao;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test.Pessoa.Funcionario.Funcao
{
    public class FuncionarioFuncaoTesteCRUD : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public FuncionarioFuncaoTesteCRUD(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Funcao Funcionario")]
        [Trait("CRUD", "FuncaoFuncionarioEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                var _funcaoRepository = new FuncaoFuncionarioImplementacao(context!);

                //var funcaoFuncionario1 = new FuncaoFuncionarioEntity
                //{
                //    Id = Guid.NewGuid(),
                //    CreateAt = DateTime.Now,
                //    FuncaoFuncionario = "Gerente",
                //    Habilitado = true,
                //    UpdateAt = DateTime.Now
                //};
                //var result1 = await _funcaoRepository.InsertAsync(funcaoFuncionario1);
                //Assert.NotNull(result1);

                //var funcaoFuncionario2 = new FuncaoFuncionarioEntity
                //{
                //    Id = Guid.NewGuid(),
                //    CreateAt = DateTime.Now,
                //    FuncaoFuncionario = "Coordenador",
                //    Habilitado = true,
                //    UpdateAt = DateTime.Now
                //};
                //var result2 = await _funcaoRepository.InsertAsync(funcaoFuncionario2);
                //Assert.NotNull(result1);
            }
        }
    }
}
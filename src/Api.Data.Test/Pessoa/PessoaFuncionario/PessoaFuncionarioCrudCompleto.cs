using Api.Data.Context;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Data.Migrations;
using Domain.Entities.Pessoa.Pessoas;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test.Pessoa.PessoaFuncionario
{
    public class PessoaFuncionarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public PessoaFuncionarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Pessoa Funcionario")]
        [Trait("CRUD", "PessoaFuncionarioEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                PessoaImplementacao _pessoaRepoository = new PessoaImplementacao(context);
                var pessoa = new PessoaEntity
                {
                    Habilitado = true,
                    CpfCnpj = "123123123-12",
                    CreateAt = DateTime.Now,
                    DataNascimentoFundacao = DateTime.Now,
                    Id = Guid.NewGuid(),
                    NomeNomeFantasia = Faker.Name.First(),
                    PessoaTipo = Domain.Enuns.Pessoas.PessoaTipoEnum.PessoaFisica,
                    RgIE = Faker.RandomNumber.Next(10, 20).ToString(),
                    SobreNomeRazaoSocial = Faker.Name.Last(),
                    UpdateAt = DateTime.Now,
                };

                var resultPessoa = await _pessoaRepoository.InsertAsync(pessoa);
            }
        }
    }
}

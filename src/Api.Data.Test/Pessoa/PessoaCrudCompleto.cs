using Api.Data.Context;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Domain.Entities.Pessoa.DadosBancarios;
using Domain.Entities.Pessoa.Pessoas;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test.Pessoa
{
    public class PessoaCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public PessoaCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Pessoa")]
        [Trait("CRUD", "PessoaEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                PessoaImplementacao _pessoaRepository = new PessoaImplementacao(context);
                var pessoa = new PessoaEntity
                {
                    Id = Guid.NewGuid(),
                    CpfCnpj = "123.123.123-12",
                    CreateAt = DateTime.Now,
                    DataNascimentoFundacao = DateTime.Now.AddYears(-30),
                    Habilitado = true,

                    NomeNomeFantasia = "Pedro ",
                    SobreNomeRazaoSocial = "Adolfo Carvalho Faria",
                    PessoaTipo = Domain.Enuns.Pessoas.PessoaTipoEnum.PessoaFisica,
                    UpdateAt = DateTime.Now,
                    RgIE = "123123-09"
                };

                var resultPessoa = await _pessoaRepository.InsertAsync(pessoa);
                Assert.NotNull(resultPessoa);


                DadosBancariosImplementacao _dadosBancariosRepository = new DadosBancariosImplementacao(context);
                var dados = new DadosBancariosEntity
                {
                    Id = Guid.NewGuid(),
                    Agencia = "12345",
                    BancoSalario = "Itau",
                    ContaComDigito = "12345-6",
                    CreateAt = DateTime.Now,
                    Habilitado = true,

                    UpdateAt = DateTime.Now
                };

                var resultDados = await _dadosBancariosRepository.InsertAsync(dados);
                Assert.NotNull(resultDados);


                PessoaDadosBancariosImplementacao _pessoaDadosBancarios = new PessoaDadosBancariosImplementacao(context);

                var pessoaDadosBancario = new PessoaDadosBancariosEntity
                {
                    PessoaEntityId = resultPessoa.Id,
                    DadosBancariosEntityId = resultDados.Id
                };

                var resultPessoaDadosBancarios = await _pessoaDadosBancarios.InsertGenericAsync(pessoaDadosBancario);
                Assert.NotNull(resultPessoaDadosBancarios);


                var pessoaGet = await _pessoaRepository.Get(resultPessoaDadosBancarios.PessoaEntityId, true);
            }
        }
    }
}

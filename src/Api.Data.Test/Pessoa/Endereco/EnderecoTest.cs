using Api.Data.Context;
using Data.Implementations.Pessoas.Endereco;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Domain.Entities.Pessoa;
using Domain.Entities.Pessoa.Endereco;
using Domain.Entities.Pessoa.PessoaEndereco;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test.Pessoa.Endereco
{
    public class EnderecoTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public EnderecoTest(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }


        [Fact(DisplayName = "Teste Endereco")]
        [Trait("CRUD", "EnderecoEntity")]
        public async Task E_Possivel_Realizar_CRUD_Endereco()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                var _repositoryEndereco = new EnderecoImplementacao(context);

                var endereco1 = new EnderecoEntity
                {
                    Id = Guid.NewGuid(),
                    Bairro = "Bairro1",
                    Cep = "11111111",
                    Complemento = "casa1",
                    CreateAt = DateTime.Now,
                    Habilitado = true,
                    Localidade = "cidade1",
                    Logradouro = "rua 1",
                    Numero = "1",
                    Uf = "AA",
                    UpdateAt = DateTime.Now,
                };

                var result1 = await _repositoryEndereco.InsertAsync(endereco1, null);
                Assert.NotNull(result1);
                Assert.Equal(result1.Localidade, "cidade1");


                var endereco2 = new EnderecoEntity
                {
                    Id = Guid.NewGuid(),
                    Bairro = "Bairro2",
                    Cep = "22222222",
                    Complemento = "casa2",
                    CreateAt = DateTime.Now,
                    Habilitado = true,
                    Localidade = "cidade2",
                    Logradouro = "rua 2",
                    Numero = "2",
                    Uf = "BB",
                    UpdateAt = DateTime.Now,
                };

                var result2 = await _repositoryEndereco.InsertAsync(endereco2,null);
                Assert.NotNull(result2);
                Assert.Equal(result2.Localidade, "cidade2");


                var enderecos = await _repositoryEndereco.SelectAsync();
                Assert.True(enderecos.Count() == 2);

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

                var resultPessoa = await _pessoaRepository.InsertAsync(pessoa,null);
                Assert.NotNull(resultPessoa);


                PessoaEnderecoImplementacao _pessoaEnderecoRepository = new PessoaEnderecoImplementacao(context);

                var pessoaEndereco = new PessoaEnderecoEntity
                {
                    EnderecoEntityId = result1.Id,
                    PessoaEntityId = resultPessoa.Id
                };

                var result = await _pessoaEnderecoRepository.InsertGenericAsync(pessoaEndereco);

            }
        }
    }
}

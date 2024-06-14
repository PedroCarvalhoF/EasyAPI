using Api.Data.Context;
using Data.Implementations.Pessoas.Contato;
using Data.Implementations.Pessoas.PessoaContato;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Domain.Entities.Pessoa;
using Domain.Entities.Pessoa.Contato;
using Domain.Entities.Pessoa.PessoaContato;

using Microsoft.Extensions.DependencyInjection;

namespace Data.Test.Pessoa.Contato
{
    public class ContatoTeste : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public ContatoTeste(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Teste Contato")]
        [Trait("CRUD", "ContatoEntity")]
        public async Task E_Possivel_Realizar_CRUD_Endereco()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {

                //PessoaImplementacao _pessoaRepository = new PessoaImplementacao(context);
                //var pessoa = new PessoaEntity
                //{
                //    Id = Guid.NewGuid(),
                //    CpfCnpj = "111.111.111-11",
                //    CreateAt = DateTime.Now,
                //    DataNascimentoFundacao = DateTime.Now.AddYears(-30),
                //    Habilitado = true,

                //    NomeNomeFantasia = "Primeiro Nome 1 ",
                //    SobreNomeRazaoSocial = "Segundo Nome 1",
                //    PessoaTipo = Domain.Enuns.Pessoas.PessoaTipoEnum.PessoaFisica,
                //    UpdateAt = DateTime.Now,
                //    RgIE = "111111-11"
                //};

                //var resultPessoa = await _pessoaRepository.InsertAsync(pessoa, null);
                //Assert.NotNull(resultPessoa);

                //ContatoImplementacao _contatoRepository = new ContatoImplementacao(context);

                //var contato1 = new ContatoEntity
                //{
                //    Id = Guid.NewGuid(),
                //    TipoContatoEnum = Domain.Enuns.Pessoas.TipoContatoEnum.Celular,
                //    Numero = "11 91111-11111",
                //    Habilitado = true,
                //    CreateAt = DateTime.Now,
                //    UpdateAt = DateTime.Now
                //};

                //var resultContato1 = await _contatoRepository.InsertAsync(contato1,null);
                //Assert.NotNull(resultContato1);

                //contato1.Numero = "1 alterado";

                //var resultContato1Update = await _contatoRepository.UpdateAsync(contato1);
                //Assert.Equal(resultContato1Update.Numero, contato1.Numero);


                //PessoaContatoImplementacao _pessoaContatoRepository = new PessoaContatoImplementacao(context);

                //var pessoaContato1 = new PessoaContatoEntity
                //{
                //    PessoaEntityId = pessoa.Id,
                //    ContatoEntityId = resultContato1.Id
                //};

                //var resultPessoaContato1 = await _pessoaContatoRepository.InsertGenericAsync(pessoaContato1);
                //Assert.NotNull(resultPessoaContato1);

                //var getPessoaContato1 = await _pessoaContatoRepository.GetPessoaContatoByPessoaId(pessoa.Id);


            }
        }
    }
}

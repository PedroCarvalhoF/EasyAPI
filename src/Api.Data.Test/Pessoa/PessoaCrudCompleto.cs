using Api.Data.Context;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Domain.Entities.Pessoa;
using Domain.Entities.Pessoa.DadosBancarios;
using Domain.Entities.Pessoa.PessoaDadosBancarios;
using Domain.Identity.UserIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Formats.Asn1.AsnWriter;

namespace Data.Test.Pessoa
{
    public class PessoaCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public PessoaCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Pessoa")]
        [Trait("CRUD", "PessoaEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                //PessoaImplementacao _pessoaRepository = new PessoaImplementacao(context);
                //var pessoa = new PessoaEntity
                //{
                //    Id = Guid.NewGuid(),
                //    CpfCnpj = "123.123.123-12",
                //    CreateAt = DateTime.Now,
                //    DataNascimentoFundacao = DateTime.Now.AddYears(-30),
                //    Habilitado = true,

                //    NomeNomeFantasia = "Pedro ",
                //    SobreNomeRazaoSocial = "Adolfo Carvalho Faria",
                //    PessoaTipo = Domain.Enuns.Pessoas.PessoaTipoEnum.PessoaFisica,
                //    UpdateAt = DateTime.Now,
                //    RgIE = "123123-09"
                //};

                //var resultPessoa = await _pessoaRepository.InsertAsync(pessoa);
                //Assert.NotNull(resultPessoa);


                //DadosBancariosImplementacao _dadosBancariosRepository = new DadosBancariosImplementacao(context);
                //var dados = new DadosBancariosEntity
                //{
                //    Id = Guid.NewGuid(),
                //    Agencia = "12345",
                //    BancoSalario = "Itau",
                //    ContaComDigito = "12345-6",
                //    CreateAt = DateTime.Now,
                //    Habilitado = true,

                //    UpdateAt = DateTime.Now
                //};

                //var resultDados = await _dadosBancariosRepository.InsertAsync(dados);
                //Assert.NotNull(resultDados);


                //PessoaDadosBancariosImplementacao _pessoaDadosBancarios = new PessoaDadosBancariosImplementacao(context);

                //var pessoaDadosBancario = new PessoaDadosBancariosEntity
                //{
                //    PessoaEntityId = resultPessoa.Id,
                //    DadosBancariosEntityId = resultDados.Id
                //};

                //var resultPessoaDadosBancarios = await _pessoaDadosBancarios.InsertGenericAsync(pessoaDadosBancario);
                //Assert.NotNull(resultPessoaDadosBancarios);


                //var pessoaGet = await _pessoaRepository.Get(resultPessoaDadosBancarios.PessoaEntityId, true);
            }
        }


       [Fact(DisplayName = "User Identity")]
        [Trait("Users", "Users_UserMasterCliente_UserMasterUsers")]
        public async Task E_Possivel_Realizar_Users_UserMasterCliente_UserMasterUsers()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                var signInManager = scope.ServiceProvider.GetService<SignInManager<User>>();

                var context = scope.ServiceProvider.GetService<MyContext>();

                User identityUser = new User
                {
                    Nome = "Pedro",
                    SobreNome = "Adolfo",
                    UserName = "pedro@ec.com",
                    Email = "pedro@ec.com",
                    EmailConfirmed = true,
                    ImagemURL = string.Empty
                };

                var result = await userManager.CreateAsync(identityUser, "123456");
                Assert.True(result.Succeeded);

                if (result.Succeeded)
                {
                    var userCreate = await userManager.SetLockoutEnabledAsync(identityUser, false);
                    Assert.True(userCreate.Succeeded);
                }
            }
        }
    }
}
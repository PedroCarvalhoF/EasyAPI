using Data.Implementations.Pessoa.Funcionario.CTPS;
using Data.Implementations.Pessoa.Funcionario.Funcao;
using Data.Implementations.Pessoas.Contato;
using Data.Implementations.Pessoas.Endereco;
using Data.Implementations.Pessoas.PessoaContato;
using Data.Implementations.Pessoas.PessoaImplentetacoes;
using Domain.Interfaces.Repository.Pessoa.Contato;
using Domain.Interfaces.Repository.Pessoa.Endereco;
using Domain.Interfaces.Repository.Pessoa.Funcionario.CTPS;
using Domain.Interfaces.Repository.Pessoa.Funcionario.Funcao;
using Domain.Interfaces.Repository.Pessoa.Pessoa;
using Domain.Interfaces.Repository.Pessoa.PessoaContato;
using Domain.Interfaces.Repository.PessoaRepositorys.Pessoa;
using Domain.Interfaces.Services.Pessoa.Funcionario.CTPS;
using Domain.Interfaces.Services.Pessoa.Funcionario.Funcao;
using Domain.Interfaces.Services.Pessoas.Contato;
using Domain.Interfaces.Services.Pessoas.Endereco;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Domain.Interfaces.Services.Pessoas.PessoaContato;
using Domain.Interfaces.Services.Pessoas.PessoaEndereco;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.Pessoa.Funcionario.CTPS;
using Service.Services.Pessoa.Funcionario.Funcao;
using Service.Services.Pessoas.Contato;
using Service.Services.Pessoas.DadosBancarios;
using Service.Services.Pessoas.Endereco;
using Service.Services.Pessoas.PessoaContato;
using Service.Services.Pessoas.PessoaEndereo;
using Service.Services.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection.Extensions
{
    public static class ConfiguracaoPessoas
    {
        public static void Pessoas(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPessoaRepository, PessoaImplementacao>();
            serviceCollection.AddScoped<IPessoaServices, PessoaServices>();

            serviceCollection.AddScoped<IDadosBancariosRepository, DadosBancariosImplementacao>();
            serviceCollection.AddScoped<IDadosBancariosServices, DadosBancariosService>();

            serviceCollection.AddScoped<IEnderecoRepository, EnderecoImplementacao>();
            serviceCollection.AddScoped<IEnderecoServices, EnderecoServices>();
            serviceCollection.AddScoped<IPessoaEnderecoServices, PessoaEnderecoServices>();

            serviceCollection.AddScoped<IContatoRepository, ContatoImplementacao>();
            serviceCollection.AddScoped<IContatoServices, ContatoService>();
            serviceCollection.AddScoped<IPessoaContatoRepositoryGeneric, PessoaContatoImplementacao>();
            serviceCollection.AddScoped<IPessoaContatoServices, PessoaContatoServices>();

            serviceCollection.AddScoped<IFuncaoFuncionarioRepository, FuncaoFuncionarioImplementacao>();
            serviceCollection.AddScoped<IFuncaoFuncionarioServices, FuncaoFuncionarioServices>();

            serviceCollection.AddScoped<ICtpsRepository, CtpsImplementacao>();
            serviceCollection.AddScoped<ICtpsServices, CtpsServices>();
        }
    }
}

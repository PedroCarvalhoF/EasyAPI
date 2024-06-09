using Api.Data.Context;
using Data.Migrations;
using Data.Repository;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Interfaces.Repository.Pessoa.Pessoa;

namespace Data.Implementations.Pessoas.PessoaImplentetacoes
{
    public class PessoaEnderecoImplementacao : RepositoryGeneric<PessoaEnderecoEntity>, IPessoaDadosBancariosRepository
    {
        public PessoaEnderecoImplementacao(MyContext context) : base(context)
        {
            
        }
    }
}

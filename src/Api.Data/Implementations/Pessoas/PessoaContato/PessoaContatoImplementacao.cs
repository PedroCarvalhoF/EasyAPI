using Api.Data.Context;
using Data.Repository;
using Domain.Entities.Pessoa.PessoaContato;
using Domain.Interfaces.Repository.Pessoa.PessoaContato;

namespace Data.Implementations.Pessoas.PessoaContato
{
    public class PessoaContatoImplementacao : RepositoryGeneric<PessoaContatoEntity>, IPessoaContatoRepositoryGeneric
    {
        public PessoaContatoImplementacao(MyContext context) : base(context)
        {
        }
    }
}

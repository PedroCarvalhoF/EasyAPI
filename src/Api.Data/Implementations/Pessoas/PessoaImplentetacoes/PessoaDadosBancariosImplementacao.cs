using Api.Data.Context;
using Data.Repository;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Interfaces.Repository.Pessoa.Pessoa;

namespace Data.Implementations.Pessoas.PessoaImplentetacoes
{
    public class PessoaDadosBancariosImplementacao : RepositoryGeneric<PessoaDadosBancariosEntity>, IPessoaDadosBancariosRepository
    {
        public PessoaDadosBancariosImplementacao(MyContext context) : base(context)
        {
        }
    }
}

using Api.Data.Context;
using Data.Repository;
using Domain.Entities.Pessoa.PessoaEndereco;
using Domain.Interfaces.Repository.Pessoa.Pessoa;

namespace Data.Implementations.Pessoas.PessoaImplentetacoes
{
    public class PessoaEnderecoImplementacao : RepositoryGeneric<PessoaEnderecoEntity>, IPessoaEnderecoRepositoryGeneric
    {
        public PessoaEnderecoImplementacao(MyContext context) : base(context)
        {

        }
    }
}

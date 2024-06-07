using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.PessoaFuncionario;
using Domain.Interfaces.Repository.Pessoa.PessoaFuncionario;

namespace Data.Implementations.Pessoas.PessoaFuncionario
{
    public class PessoaFuncionarioImplementacao : BaseRepository<PessoaFuncionarioEntity>, IPessoaFuncionarioRepository
    {
        public PessoaFuncionarioImplementacao(MyContext context) : base(context)
        {
        }
    }
}

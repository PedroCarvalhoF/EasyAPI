using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.Pessoa.PessoaTipo;
using Domain.Interfaces.Repository.PessoaRepositorys.PessoaTipo;

namespace Data.Implementations.Pessoas.PessoasTipoImplementacao
{
    public class PessoaTipoImplementecao : BaseRepository<PessoaTipoEntity>, IPessoaTipoRepository
    {
        public PessoaTipoImplementecao(MyContext context) : base(context)
        {
        }
    }
}

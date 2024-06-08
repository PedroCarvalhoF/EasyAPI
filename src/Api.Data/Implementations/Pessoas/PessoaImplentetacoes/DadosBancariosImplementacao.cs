using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Interfaces.Repository.Pessoa.Pessoa;

namespace Data.Implementations.Pessoas.PessoaImplentetacoes
{
    public class DadosBancariosImplementacao : BaseRepository<DadosBancariosEntity>, IDadosBancariosRepository
    {
        public DadosBancariosImplementacao(MyContext context) : base(context)
        {
        }
    }
}

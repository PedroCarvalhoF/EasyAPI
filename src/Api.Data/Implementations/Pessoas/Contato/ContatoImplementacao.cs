using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Contato;
using Domain.Interfaces.Repository.Pessoa.Contato;

namespace Data.Implementations.Pessoas.Contato
{
    public class ContatoImplementacao : BaseRepository<ContatoEntity>, IContatoRepository
    {
        public ContatoImplementacao(MyContext context) : base(context)
        {
        }
    }
}

using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Endereco;
using Domain.Interfaces.Repository.Pessoa.Endereco;

namespace Data.Implementations.Pessoas.Endereco
{
    public class EnderecoImplementacao : BaseRepository<EnderecoEntity>, IEnderecoRepository
    {
        public EnderecoImplementacao(MyContext context) : base(context)
        {
        }
    }
}

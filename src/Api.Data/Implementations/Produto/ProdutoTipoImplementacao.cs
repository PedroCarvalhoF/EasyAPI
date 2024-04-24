using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Produto;
using Domain.Repository.Produto;

namespace Data.Implementations.Produto
{
    public class ProdutoTipoImplementacao : BaseRepository<ProdutoEntity>, IProdutoTipoRepository
    {
        public ProdutoTipoImplementacao(MyContext context) : base(context)
        {
        }
    }
}

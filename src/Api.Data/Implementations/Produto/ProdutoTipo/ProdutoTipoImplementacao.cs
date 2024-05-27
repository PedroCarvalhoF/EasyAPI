using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Produto;
using Domain.Interfaces.Repository.Produto;

namespace Data.Implementations.Produto.ProdutoTipo
{
    public class ProdutoTipoImplementacao : BaseRepository<ProdutoEntity>, IProdutoTipoRepository
    {
        public ProdutoTipoImplementacao(MyContext context) : base(context)
        {
        }
    }
}

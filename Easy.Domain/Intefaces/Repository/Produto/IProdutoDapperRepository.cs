using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;

namespace Easy.Domain.Intefaces.Repository.Produto
{
    public interface IProdutoDapperRepository<F> where F : FiltroBase
    {
        Task<IEnumerable<ProdutoEntity>> GetProdutosAsync(F filtro);
        Task<ProdutoEntity> GetProdutoById(Guid idProduto, F filtro);
    }
}

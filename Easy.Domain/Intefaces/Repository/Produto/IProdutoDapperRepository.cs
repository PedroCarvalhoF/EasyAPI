using Easy.Domain.Entities;
using Easy.Domain.EntitiesBD.Produto;

namespace Easy.Domain.Intefaces.Repository.Produto
{
    public interface IProdutoDapperRepository<F> where F : FiltroBase
    {
        Task<IEnumerable<ProdutoEntityViewBD>> GetAllProdutosAsync(F filtro);
    }
}

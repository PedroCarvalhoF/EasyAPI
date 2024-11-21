using Easy.Domain.Entities;
using Easy.Domain.EntitiesBD.Produto;

namespace Easy.Domain.Intefaces.Repository.Produto
{
    public interface IProdutoDapperRepository<F> where F : FiltroBase
    {
        Task<IEnumerable<ProdutoEntityViewBD>> GetProdutoByIdAsync(F filtro, Guid produtoId);
        Task<IEnumerable<ProdutoEntityViewBD>> GetAllProdutosAsync(F filtro);           
        Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByHabilitadoAsync(FiltroBase filtro, bool value);
        Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByNomeDescricaoEqualsAsync(FiltroBase filtro, string nomeDescricaoEquals);
        Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByNomeDescricaoContainsAsync(FiltroBase filtro, string nomeDescricaoContains);
        Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByCategoriaIdAsync(FiltroBase filtro, Guid? idCategoria);
        Task<IEnumerable<ProdutoEntityViewBD>> GetProdutosByCodigoAsync(FiltroBase filtro, string codigo);
    }
}

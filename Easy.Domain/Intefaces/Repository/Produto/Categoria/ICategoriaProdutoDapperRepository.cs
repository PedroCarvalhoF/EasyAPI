using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;

namespace Easy.Domain.Intefaces.Repository.Produto.Categoria;

public interface ICategoriaProdutoDapperRepository<F> where F : FiltroBase
{
    Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriasProdutoAsync(F filtro);
    Task<CategoriaProdutoEntity> GetCategoriaProdutoByIdCategoria(Guid? idCategoria, F filtro);
    Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriaProdutoEqualsCategoriaQuery(FiltroBase filtro, string descricaoCategoria);
    Task<IEnumerable<CategoriaProdutoEntity>> GetCategoriaProdutoContainsCategoriaQuery(FiltroBase filtro, string descricaoCategoria);
}

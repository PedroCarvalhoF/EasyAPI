using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;

namespace Easy.Domain.Intefaces.Repository.Produto
{
    public interface ICategoriaProdutoRepository<T, F> where T : CategoriaProdutoEntity where F : FiltroBase
    {
        Task<IEnumerable<T>> GetCategoriasAsync(F filtro);
        Task<T> GetCategoriaByIdAsync(Guid idCategoria, F filtro);
        Task<T> AddCategoriaAsync(T categoria, F filtro);
        void UpdateCategoria(T categoria, F filtro);
        Task<T> DeleteCategoria(Guid idCategoria, F filtro);
    }
}

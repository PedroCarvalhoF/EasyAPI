using Domain.Entities.CategoriaProduto;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriaProdutoRepository
    {
        Task<IEnumerable<CategoriaProdutoEntity>> Get(string categoria);
    }
}

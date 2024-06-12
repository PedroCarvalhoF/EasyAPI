using Domain.Entities.CategoriaProduto;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriaProdutoRepository
    {
        Task<IEnumerable<CategoriaProdutoEntity>> GetAll();
        Task<CategoriaProdutoEntity> GetIdCategoriaProduto(Guid id);
    }
}

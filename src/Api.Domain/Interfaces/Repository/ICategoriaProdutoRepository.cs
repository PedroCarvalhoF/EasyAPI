using Domain.Entities.CategoriaProduto;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriaProdutoRepository
    {
        Task<IEnumerable<CategoriaProdutoEntity>> GetAll(Guid? filtroId);
        Task<CategoriaProdutoEntity> GetIdCategoriaProduto(Guid id, Guid? filtroId);
    }
}

using Domain.Entities.CategoriaProduto;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriaProdutoRepository
    {
        Task<IEnumerable<CategoriaProdutoEntity>> GetAll(UserMasterUserDtoCreate user);
        Task<CategoriaProdutoEntity> GetByIdCategoria(Guid idCategoria, UserMasterUserDtoCreate user);
    }
}

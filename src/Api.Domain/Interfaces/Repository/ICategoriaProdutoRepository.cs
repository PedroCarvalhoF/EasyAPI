using Domain.Entities.CategoriaProduto;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriaProdutoRepository
    {
        
        Task<IEnumerable<CategoriaProdutoEntity>> GetAll(UserMasterUserDtoCreate user);
        Task<bool> Exists(string? descricaoCategoria, UserMasterUserDtoCreate users);
        Task<CategoriaProdutoEntity> GetByIdCategoria(Guid idCategoria, UserMasterUserDtoCreate user);
    }
}

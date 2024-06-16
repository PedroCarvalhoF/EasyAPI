using Domain.Entities.Produto;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository.Produto
{
    public interface IProdutoRepository
    {
        Task<bool> CodigoExists(string? codigoBarrasPersonalizado, UserMasterUserDtoCreate users);
        Task<bool> NomeProdutoExists(string? nomeProduto, UserMasterUserDtoCreate users);
        Task<IEnumerable<ProdutoEntity>> GetAll(UserMasterUserDtoCreate users);
        Task<ProdutoEntity> GetByIdProduto(Guid id, UserMasterUserDtoCreate users);
      
    }
}

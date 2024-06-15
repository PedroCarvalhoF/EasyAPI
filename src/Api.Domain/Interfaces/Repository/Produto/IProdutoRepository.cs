using Domain.Entities.Produto;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository.Produto
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoEntity>> GetAll(UserMasterUserDtoCreate users);
        Task<ProdutoEntity> GetByIdProduto(Guid id, UserMasterUserDtoCreate users);
    }
}

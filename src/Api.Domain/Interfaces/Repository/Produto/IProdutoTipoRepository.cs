using Domain.Entities.ProdutoTipo;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository.Produto
{
    public interface IProdutoTipoRepository
    {
        Task<IEnumerable<ProdutoTipoEntity>> GetAll(UserMasterUserDtoCreate users);
        Task<ProdutoTipoEntity> GetByIdTipoProduto(Guid id, UserMasterUserDtoCreate users);
    }
}

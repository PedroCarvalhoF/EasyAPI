using Api.Domain.Entities.ProdutoMedida;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository.Produto
{
    public interface IProdutoMedidaRepository
    {

        Task<IEnumerable<ProdutoMedidaEntity>> GetAll(UserMasterUserDtoCreate users);
        Task<ProdutoMedidaEntity> GetByIdMididaProduto(Guid id, UserMasterUserDtoCreate users);
    }
}

using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Entities.PrecoProduto;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository
{
    public interface IPrecoProdutoRepository
    {
        Task<IEnumerable<PrecoProdutoEntity>> GetAll(UserMasterUserDtoCreate users);
        Task<PrecoProdutoEntity> PrecoProdutoExists(PrecoProdutoDtoCreate create, UserMasterUserDtoCreate users);
    }
}

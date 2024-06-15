using Domain.Dtos;
using Domain.Dtos.ProdutoDtos;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Services.Produto
{
    public interface IProdutoService
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate users);
        Task<RequestResult> GetByIdProduto(Guid id, UserMasterUserDtoCreate users);
        Task<RequestResult> Create(ProdutoDtoCreate create, UserMasterUserDtoCreate users);
        Task<RequestResult> Update(ProdutoDtoUpdate update, UserMasterUserDtoCreate users);
    }
}

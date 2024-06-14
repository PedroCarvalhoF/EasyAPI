using Api.Domain.Dtos.CategoriaProdutoDtos;
using Domain.Dtos;
using Domain.Dtos.CategoriaProdutoDtos;
using Domain.UserIdentity.Masters;

namespace Api.Domain.Interfaces.Services.CategoriaProduto
{
    public interface ICategoriaProdutoService
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate user);
        Task<RequestResult> GetByIdCategoria(Guid id, UserMasterUserDtoCreate user);
        Task<RequestResult> Create(CategoriaProdutoDtoCreate create, UserMasterUserDtoCreate user);
        Task<RequestResult> Update(CategoriaProdutoDtoUpdate update, UserMasterUserDtoCreate user);


    }
}

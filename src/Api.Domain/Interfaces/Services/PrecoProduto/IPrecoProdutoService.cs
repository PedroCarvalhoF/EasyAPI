using Api.Domain.Dtos.PrecoProdutoDtos;
using Domain.Dtos;
using Domain.UserIdentity.Masters;

namespace Api.Domain.Interfaces.Services.PrecoProdutoService
{
    public interface IPrecoProdutoService
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate users);        
        Task<RequestResult> CreateUpdate(PrecoProdutoDtoCreate create, UserMasterUserDtoCreate users);
    }
}
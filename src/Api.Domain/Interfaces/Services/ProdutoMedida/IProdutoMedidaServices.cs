using Api.Domain.Dtos.ProdutoMedidaDtos;
using Domain.Dtos;
using Domain.UserIdentity.Masters;

namespace Api.Domain.Interfaces.Services.ProdutoMedida
{
    public interface IProdutoMedidaServices
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate users);
        Task<RequestResult> GetByIdMididaProduto(Guid id, UserMasterUserDtoCreate users);
        Task<RequestResult> Create(ProdutoMedidaDtoCreate create, UserMasterUserDtoCreate users);
        Task<RequestResult> Update(ProdutoMedidaDtoUpdate update, UserMasterUserDtoCreate users);      
    }
}
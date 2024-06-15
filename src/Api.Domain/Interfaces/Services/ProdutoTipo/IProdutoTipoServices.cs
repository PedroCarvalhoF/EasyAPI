using Domain.Dtos;
using Domain.Dtos.ProdutoTipo;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Services.ProdutoTipo
{
    public interface IProdutoTipoServices
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate users);
        Task<RequestResult> GetByIdTipoProduto(Guid id, UserMasterUserDtoCreate users);
        Task<RequestResult> Create(ProdutoTipoDtoCreate create, UserMasterUserDtoCreate users);
        Task<RequestResult> Update(ProdutoTipoDtoUpdate update, UserMasterUserDtoCreate users);
    }
}

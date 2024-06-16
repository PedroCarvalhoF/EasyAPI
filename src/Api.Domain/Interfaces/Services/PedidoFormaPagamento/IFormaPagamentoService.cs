using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Services.FormaPagamento
{
    public interface IFormaPagamentoService
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate user);
        Task<RequestResult> GetById(Guid formaPagamentoId, UserMasterUserDtoCreate user);
        Task<RequestResult> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate, UserMasterUserDtoCreate user);
        Task<RequestResult> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate, UserMasterUserDtoCreate user);

    }
}

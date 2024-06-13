using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;
using Domain.UserIdentity.MasterUsers;

namespace Domain.Interfaces.Services.FormaPagamento
{
    public interface IFormaPagamentoService
    {
        Task<RequestResult> GetAll(UserMasterUserEntity user);
        Task<ResponseDto<List<FormaPagamentoDto>>> GetById(Guid id, UserMasterUserEntity user);
        Task<ResponseDto<List<FormaPagamentoDto>>> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate, UserMasterUserEntity user);
        Task<ResponseDto<List<FormaPagamentoDto>>> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate, UserMasterUserEntity user);
        Task<ResponseDto<List<FormaPagamentoDto>>> DesabilitarHabilitar(Guid id, UserMasterUserEntity user);
        Task<ResponseDto<List<FormaPagamentoDto>>> GetByDescricao(string descricao, UserMasterUserEntity user);
    }
}

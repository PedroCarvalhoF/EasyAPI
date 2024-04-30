using Domain.Dtos;
using Domain.Dtos.FormaPagamentoDtos;

namespace Domain.Interfaces.Services.FormaPagamento
{
    public interface IFormaPagamentoService
    {
        Task<ResponseDto<List<FormaPagamentoDto>>> GetAll();
        Task<ResponseDto<List<FormaPagamentoDto>>> GetById(Guid id);
        Task<ResponseDto<List<FormaPagamentoDto>>> Create(FormaPagamentoDtoCreate formaPagamentoDtoCreate);
        Task<ResponseDto<List<FormaPagamentoDto>>> Update(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate);
        Task<ResponseDto<List<FormaPagamentoDto>>> DesabilitarHabilitar(Guid id);

    }
}

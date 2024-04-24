using Domain.Dtos.FormaPagamentoDtos;

namespace Domain.Interfaces.Services.FormaPagamento
{
    public interface IFormaPagamentoService
    {
        Task<FormaPagamentoDto> CadastrarFormaPg(FormaPagamentoDtoCreate formaPagamentoDtoCreate);
        Task<FormaPagamentoDto> AlterarFormaPg(FormaPagamentoDtoUpdate formaPagamentoDtoUpdate);
        Task<IEnumerable<FormaPagamentoDto>> GetAll();
    }
}

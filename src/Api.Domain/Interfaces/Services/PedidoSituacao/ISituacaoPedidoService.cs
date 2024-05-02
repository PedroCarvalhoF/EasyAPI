using Domain.Dtos;
using Domain.Dtos.PedidoSituacao;

namespace Domain.Interfaces.Services.PedidoSituacao
{
    public interface ISituacaoPedidoService
    {
        Task<ResponseDto<List<SituacaoPedidoDto>>> GetAll();
        Task<ResponseDto<List<SituacaoPedidoDto>>> Get(Guid id);
        Task<ResponseDto<List<SituacaoPedidoDto>>> Get(string descricao);
        Task<ResponseDto<List<SituacaoPedidoDto>>> Create(SituacaoPedidoDtoCreate create);
        Task<ResponseDto<List<SituacaoPedidoDto>>> Update(SituacaoPedidoDtoUpdate update);
        Task<ResponseDto<List<SituacaoPedidoDto>>> Desabilitar(Guid id);
    }
}

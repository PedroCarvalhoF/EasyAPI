using Domain.Dtos;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Dtos.PedidoPagamento;

namespace Domain.Interfaces.Services.PagamentoPedido
{
    public interface IPagamentoPedidoService
    {
        Task<ResponseDto<List<PagamentoPedidoDto>>> GetAll();
        Task<ResponseDto<List<PagamentoPedidoDto>>> GetPagamentoPedidoByIdPedido(Guid pedidoId);
        Task<ResponseDto<List<PagamentoPedidoDto>>> CreatePagamentoPedido(PagamentoPedidoDtoCreate pgPedido);
        Task<ResponseDto<List<PagamentoPedidoDto>>> UpdatePagamentoPedido(PagamentoPedidoDtoUpdate pgUpdate);

    }
}

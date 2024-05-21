using Domain.Dtos;
using Domain.Dtos.PagamentoPedidoDtos;

namespace Domain.Interfaces.Services.PagamentoPedido
{
    public interface IPagamentoPedidoService
    {
        Task<ResponseDto<List<PagamentoPedidoDto>>> GetAll();
        Task<ResponseDto<List<PagamentoPedidoDto>>> Get(Guid idPagamento);
        Task<ResponseDto<List<PagamentoPedidoDto>>> GetByIdPedido(Guid idPedido);
        Task<ResponseDto<List<PagamentoPedidoDto>>> InserirPagamentoPedido(PagamentoPedidoDtoCreate pgPedido);
        Task<ResponseDto<List<PagamentoPedidoDto>>> RemoverPagamentoPedido(Guid idPagamento);
        Task<ResponseDto<List<PagamentoPedidoDto>>> InserirArrayPagamentoPedido(List<PagamentoPedidoDtoCreate> listPagamentoCreate);
    }
}

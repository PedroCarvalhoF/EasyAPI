using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.PagamentoPedidoDtos;

namespace Domain.Interfaces.Services.PagamentoPedido
{
    public interface IPagamentoPedidoService
    {
        Task<IEnumerable<PagamentoPedidoDto>> ConsultarPagamentosPedidoByIdPedido(Guid idPedido);
        Task<PedidoDto> InseririPagamentoPedido(PagamentoPedidoDtoCreate pagamentoPedidoDto);
        Task<bool> InseririPagamentoPedidoLote(IEnumerable<PagamentoPedidoDtoCreate> pgts);
        Task<IEnumerable<PagamentoPedidoDto>> RemoverPagamentosPedidoByIdPagamento(Guid idPagamento);
        Task<bool> RemoverPagamentosPedidoByIdPedido(Guid idPedido);
    }
}

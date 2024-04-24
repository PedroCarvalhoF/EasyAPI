using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.PedidoDtos;
using Domain.Enuns;

namespace Api.Domain.Interfaces.Services.Pedido
{
    public interface IPedidoService
    {
        Task<PedidoDto> GerarPedido(PedidoDtoCreate pedidoDtoCreate);
        Task<PedidoDto> EncerrarPedido(Guid pedidoId);
        Task<PedidoDto> CancelarPedido(PedidoDtoCancelamento dtoCancelamento);
        Task<PedidoDto> AtualizarValorPedido(Guid pedidoId);
        Task<IEnumerable<PedidoDto>> Get(SituacaoPedidoEnum situacaoPedido);
        Task<IEnumerable<PedidoDto>> GetByIdPedido(Guid idPedido, bool fullConsulta);
        Task<IEnumerable<PedidoDto>> Get(Guid idPdv);
        Task<PedidoDto> CancelarTodosItensPedidoReturnPedido(Guid idPedido);
        Task<PedidoDto> RemoverAllItensPedido(Guid idPedido);
    }
}

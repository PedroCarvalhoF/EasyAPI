using Easy.Domain.Entities;
using Easy.Services.DTOs.Pedido;

namespace Easy.Services.Service.Pedido;

public interface IPedidoServices
{
    Task<bool> AtualizarPedido(Guid idPedido, FiltroBase filtro);
    Task<PedidoDto> GetPedidoById(Guid idPedido, FiltroBase filtro);
}

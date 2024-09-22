using Easy.Domain.Entities;
using Easy.Services.DTOs.Pedido;

namespace Easy.Services.Service.Pedido;

public interface IPedidoServices
{
    Task<PedidoDto> AtualizarPedido(Guid idPedido, FiltroBase filtro);
}

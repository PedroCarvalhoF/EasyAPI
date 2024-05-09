using Domain.Dtos;
using Domain.Dtos.ItemPedido;

namespace Domain.Interfaces.Services.ItemPedido
{
    public interface IItemPedidoService
    {
        Task<ResponseDto<List<ItemPedidoDto>>> Get(Guid id);
        Task<ResponseDto<List<ItemPedidoDto>>> GetByIdPedido(Guid idPedido);
        Task<ResponseDto<List<ItemPedidoDto>>> GerarItemPedido(ItemPedidoDtoCreate itemPedido);
        Task<ResponseDto<List<ItemPedidoDto>>> CancelarItemPedido(Guid id);
        
    }
}

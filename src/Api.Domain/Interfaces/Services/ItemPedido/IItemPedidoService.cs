using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.ItemPedido;

namespace Domain.Interfaces.Services.ItemPedido
{
    public interface IItemPedidoService
    {
        Task<ItemPedidoDto> CancelarItemPedido(Guid idItemPedido);
        Task<PedidoDto> CancelarItemPedidoReturnPedido(Guid idItemPedido);
        Task<ItemPedidoDto> GetByIdItemPedido(Guid idItemPedido);
        Task<IEnumerable<ItemPedidoDto>> GetByIdProduto(Guid idProduto, bool fullConsulta = false);
        Task<IEnumerable<ItemPedidoDto>> GetBySituacaoItem(int situacaoItem, bool fullConsulta);
        Task<ItemPedidoDto> RegistrarItemPedido(ItemPedidoDtoCreate itemPedido);
        Task<PedidoDto> ResgistrarItemReturnPedido(ItemPedidoDtoCreate itemPedidoCreate);
    }
}

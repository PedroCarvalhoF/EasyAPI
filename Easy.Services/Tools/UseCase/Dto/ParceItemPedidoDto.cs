using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Services.DTOs.ItemPedido;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static ItemPedidoDto ParceItemPedidoDto(ItemPedidoEntity item)
        {
            return new ItemPedidoDto(item.Id, item.CreateAt, item.Produto.Id, item.Produto.NomeProduto, item.Produto.Codigo, item.Quantidade, item.Preco, item.DescontoItem, item.SubTotalItem, item.TotalItem, item.Cancelado, item.PedidoId, item.Pedido.NumeroPedido);
        }

        public static IEnumerable<ItemPedidoDto> ParceItemPedidoDto(IEnumerable<ItemPedidoEntity> itens)
        {
            foreach (var item in itens)
            {
                yield return ParceItemPedidoDto(item);
            }
        }
    }
}

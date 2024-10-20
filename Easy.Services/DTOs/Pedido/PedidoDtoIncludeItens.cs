using Easy.Domain.Enuns.Pdv.Pedido;
using Easy.Services.DTOs.ItemPedido;

namespace Easy.Services.DTOs.Pedido;

public class PedidoDtoIncludeItens : PedidoDto
{
    public List<ItemPedidoDto>? ItensPedido { get; private set; }
    public PedidoDtoIncludeItens(List<ItemPedidoDto>? itensPedido, Guid id, TipoPedidoEnum? tipoPedido, string? numeroPedido, decimal? desconto, decimal? subTotal, decimal? total, string? observacoes, bool? cancelado, Guid? pontoVendaEntityId, Guid? categoriaPrecoId, string? categoriaPreco, Guid? userId, DateTime createAt, bool finalizado)
        : base(id, tipoPedido, numeroPedido, desconto, subTotal, total, observacoes, cancelado, pontoVendaEntityId, categoriaPrecoId, categoriaPreco, userId, createAt, finalizado)
    {
        ItensPedido = itensPedido;
    }
}

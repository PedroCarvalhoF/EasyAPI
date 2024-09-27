using Easy.Domain.Enuns.Pdv.Pedido;
using Easy.Services.DTOs.ItemPedido;

namespace Easy.Services.DTOs.Pedido;

public class PedidoDtoCompleto : PedidoDto
{
    public PedidoDtoCompleto(Guid id, TipoPedidoEnum? tipoPedido, string? numeroPedido, decimal? desconto, decimal? subTotal, decimal? total, string? observacoes, bool? cancelado, Guid? pontoVendaEntityId, Guid? categoriaPrecoId, string? categoriaPreco, Guid? userId, DateTime createAt, bool finalizado, List<ItemPedidoDto> itensPedidoDtos) : base(id, tipoPedido, numeroPedido, desconto, subTotal, total, observacoes, cancelado, pontoVendaEntityId, categoriaPrecoId, categoriaPreco, userId, createAt, finalizado)
    {
        ItensPedidoDtos = itensPedidoDtos;
    }

    public List<ItemPedidoDto> ItensPedidoDtos { get; private set; }
}

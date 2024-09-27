using Easy.Domain.Enuns.Pdv.Pedido;

namespace Easy.Services.DTOs.Pedido;

public class PedidoDto
{
    public Guid Id { get; private set; }
    public TipoPedidoEnum? TipoPedido { get; private set; }
    public DateTime CreateAt { get; private set; }
    public string? NumeroPedido { get; private set; }
    public decimal? Desconto { get; private set; } // desconto
    public decimal? SubTotal { get; private set; } // soma dos itens válidos do pedido
    public decimal? Total { get; private set; } // soma dos itens - desconto
    public string? Observacoes { get; private set; }
    public bool? Cancelado { get; private set; }
    public Guid? PontoVendaEntityId { get; private set; }
    public Guid? CategoriaPrecoId { get; private set; }
    public string? CategoriaPreco { get; private set; }
    public Guid? UserId { get; private set; }
    public bool Finalizado { get; private set; }

    public PedidoDto(Guid id, TipoPedidoEnum? tipoPedido, string? numeroPedido, decimal? desconto, decimal? subTotal, decimal? total, string? observacoes, bool? cancelado, Guid? pontoVendaEntityId, Guid? categoriaPrecoId, string? categoriaPreco, Guid? userId, DateTime createAt, bool finalizado)
    {
        Id = id;
        TipoPedido = tipoPedido;
        CreateAt = createAt;
        NumeroPedido = numeroPedido;
        Desconto = desconto;
        SubTotal = subTotal;
        Total = total;
        Observacoes = observacoes;
        Cancelado = cancelado;
        PontoVendaEntityId = pontoVendaEntityId;
        CategoriaPrecoId = categoriaPrecoId;
        CategoriaPreco = categoriaPreco;
        UserId = userId;
        Finalizado = finalizado;
    }
}

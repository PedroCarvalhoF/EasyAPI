namespace Easy.Domain.Entities.PDV.Pedido;

public class PedidoEntityFilter
{
    public Guid? IdPedido { get; set; }
    public string? NumeroPedido { get; set; }
    public Guid? PontoVendaEntityId { get; set; }
    public bool? Finalizado { get; set; }
    public bool? Cancelado { get; set; }
    public Guid? FormaPagamentoId { get; set; }
    public Guid? ProdutoId { get; set; }
    public Guid? CategoriaPrecoId { get; set; }
    public decimal? TotalPedido { get; set; }
    public static IQueryable<PedidoEntity> QueryablePedidoEntity(IQueryable<PedidoEntity> query, PedidoEntityFilter filtro)
    {

        if (filtro.TotalPedido != null && filtro.TotalPedido > 0)
        {
            query = query.Where(pedido => pedido.Total == filtro.TotalPedido);
        }

        if (filtro.CategoriaPrecoId != null && filtro.CategoriaPrecoId != Guid.Empty)
        {
            query = query.Where(pedido => pedido.CategoriaPrecoId == filtro.CategoriaPrecoId);
        }

        if (filtro.CategoriaPrecoId != null && filtro.CategoriaPrecoId != Guid.Empty)
        {
            query = query.Where(pedido => pedido.CategoriaPrecoId == filtro.CategoriaPrecoId);
        }

        if (filtro.ProdutoId != null && filtro.ProdutoId != Guid.Empty)
        {
            query = query.Where(pedido => pedido.ItensPedido != null &&
                                        pedido.ItensPedido.Any(itens => itens.ProdutoId == filtro.ProdutoId));
        }


        if (filtro.FormaPagamentoId != null && filtro.FormaPagamentoId != Guid.Empty)
        {
            query = query.Where(pedido => pedido.Pagamentos != null &&
                                          pedido.Pagamentos.Any(pgt => pgt.FormaPagamentoId == filtro.FormaPagamentoId));
        }

        if (filtro.Cancelado.HasValue)
        {
            query = query.Where(pedido => pedido.Cancelado == filtro.Cancelado);
        }

        if (filtro.Finalizado.HasValue)
        {
            query = query.Where(pedido => pedido.Finalizado == filtro.Finalizado);
        }

        if (filtro.PontoVendaEntityId.HasValue)
        {
            query = query.Where(pedido => pedido.PontoVendaEntityId == filtro.PontoVendaEntityId.Value);
        }

        if (filtro.IdPedido.HasValue)
        {
            query = query.Where(pedido => pedido.Id == filtro.IdPedido.Value);
        }

        if (filtro.NumeroPedido != null)
        {
            query = query.Where(pedido => pedido.NumeroPedido == filtro.NumeroPedido);
        }

        return query;
    }
}

namespace Easy.Domain.Entities.PDV.Pedido;

public class PedidoEntityFilter
{
    public Guid? IdPedido { get; set; }
    public string? NumeroPedido { get; set; }
    public Guid? PontoVendaEntityId { get; set; }
    public bool? Finalizado { get; set; }
    public bool? Cancelado { get; set; }
    public static IQueryable<PedidoEntity> QueryablePedidoEntity(IQueryable<PedidoEntity> query, PedidoEntityFilter filtro)
    {
        if(filtro.Cancelado.HasValue)
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

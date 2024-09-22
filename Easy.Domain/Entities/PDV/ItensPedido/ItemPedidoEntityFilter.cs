
namespace Easy.Domain.Entities.PDV.ItensPedido
{
    public class ItemPedidoEntityFilter
    {
        public Guid? PedidoId { get; set; }
        public Guid? ProdutoId { get; set; }
        public bool? Cancelado { get; set; }
        public static IQueryable<ItemPedidoEntity> QueryablePedidoEntity(IQueryable<ItemPedidoEntity> query, ItemPedidoEntityFilter filtro)
        {
            if (filtro.PedidoId != Guid.Empty)
            {
                query = query.Where(item => item.PedidoId == filtro.PedidoId);
            }
            if (filtro.ProdutoId != Guid.Empty)
            {
                query = query.Where(item => item.ProdutoId == filtro.ProdutoId);
            }
            //if (filtro.Cancelado.HasValue)
            //{
            //    query = query.Where(item => item.Cancelado == filtro.Cancelado);
            //}

            return query;
        }
    }
}

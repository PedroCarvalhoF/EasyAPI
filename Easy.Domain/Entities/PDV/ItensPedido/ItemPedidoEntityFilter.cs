
namespace Easy.Domain.Entities.PDV.ItensPedido
{
    public class ItemPedidoEntityFilter
    {
        public Guid? IdItem { get; set; }
        public List<Guid>? IdsItens { get; set; }
        public Guid? PedidoId { get; set; }
        public Guid? ProdutoId { get; set; }
        public Guid? PontoVendaId { get; set; }
        public SituacaoItem? ValidoCanceladoAmbos { get; set; }

        public enum SituacaoItem
        {
            Validos = 1,
            Cancelados = 2,
            Ambos = 3
        }

        public static IQueryable<ItemPedidoEntity> QueryablePedidoEntity(IQueryable<ItemPedidoEntity> query, ItemPedidoEntityFilter filtro)
        {

            if (filtro.ValidoCanceladoAmbos != null)
            {
                switch (filtro.ValidoCanceladoAmbos)
                {
                    case SituacaoItem.Validos:
                        query = query.Where(item => item.Cancelado == false);
                        break;

                    case SituacaoItem.Cancelados:
                        query = query.Where(item => item.Cancelado == true);
                        break;

                    case SituacaoItem.Ambos:
                        query = query.Where(item => item.Cancelado == false && item.Cancelado == true);
                        break;

                    default:
                        break;
                }
            }


            if (filtro.PontoVendaId != null && filtro.PontoVendaId != Guid.Empty)
            {
                query = query.Where(item => item.Pedido!.PontoVendaEntity!.Id == filtro.PontoVendaId);
            }

            if (filtro.IdItem != null && filtro.IdItem != Guid.Empty)
            {
                query = query.Where(item => item.Id == filtro.IdItem);
            }

            if (filtro.IdsItens != null && filtro.IdsItens.Any())
            {
                query = query.Where(item => filtro.IdsItens.Contains(item.Id));
            }

            if (filtro.PedidoId != null && filtro.PedidoId != Guid.Empty)
            {
                query = query.Where(item => item.PedidoId == filtro.PedidoId);
            }

            if (filtro.ProdutoId != null && filtro.ProdutoId != Guid.Empty)
            {
                query = query.Where(item => item.ProdutoId == filtro.ProdutoId);
            }


            return query;
        }
    }
}

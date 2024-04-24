using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.PagamentoPedido;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class PagamentoPedidoImplementacao : BaseRepository<PagamentoPedidoEntity>, IPagamentoPedidoRepository
    {
        private readonly DbSet<PagamentoPedidoEntity> _dataset;

        public PagamentoPedidoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<PagamentoPedidoEntity>();
            _dataset.AsNoTracking();
        }

        public async Task<IEnumerable<PagamentoPedidoEntity>> ConsultarPagamentosPedidoByIdPedido(Guid idPedido)
        {
            try
            {
                IQueryable<PagamentoPedidoEntity>? query = _context?.PagamentosPedidos?.AsNoTracking();

                query = GetQueryable(query);
                query = query.Where(pgt => pgt.PedidoEntityId.Equals(idPedido));

                PagamentoPedidoEntity[] entities = await query.ToArrayAsync();

                return entities;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        private static IQueryable<PagamentoPedidoEntity> GetQueryable(IQueryable<PagamentoPedidoEntity>? query)
        {
            //include- Pedido

            //Include-Forma de Pagamento
            query = query?.Include(fpg => fpg.FormaPagamentoEntity);

            return query;
        }
    }
}

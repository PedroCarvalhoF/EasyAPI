using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.PagamentoPedido;
using Domain.Interfaces.Repository.PedidoPagamento;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PedidoPagamento
{
    public class PagamentoPedidoImplementacao : BaseRepository<PagamentoPedidoEntity>, IPagamentoPedidoRepository
    {
        private readonly DbSet<PagamentoPedidoEntity> _dataset;

        public PagamentoPedidoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<PagamentoPedidoEntity>();
            _dataset.AsNoTracking();
        }


        public async Task<IEnumerable<PagamentoPedidoEntity>> GetAll()
        {
            IQueryable<PagamentoPedidoEntity>? query = _dataset.AsNoTracking();

            query = Include(query);

            //query = query.Where();

            var entities = await query.ToArrayAsync();

            return entities;
        }

        public async Task<IEnumerable<PagamentoPedidoEntity>> GetPagamentoPedidoByIdPedido(Guid idPedido)
        {
            try
            {
                IQueryable<PagamentoPedidoEntity>? query = _dataset.AsNoTracking();

                query = Include(query);

                query = query.Where(pgt => pgt.PedidoEntityId.Equals(idPedido));

                var entities = await query.ToArrayAsync();

                return entities;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PagamentoPedidoEntity> Exists(Guid pedidoEntityId, Guid formaPagamentoEntityId)
        {
            try
            {
                IQueryable<PagamentoPedidoEntity>? query = _dataset.AsNoTracking();

                query = Include(query);

                query = query.Where(pgt => pgt.PedidoEntityId.Equals(pedidoEntityId) && pgt.FormaPagamentoEntityId.Equals(formaPagamentoEntityId));

                var entities = await query.FirstOrDefaultAsync();

                return entities;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        private static IQueryable<PagamentoPedidoEntity> Include(IQueryable<PagamentoPedidoEntity>? query)
        {

            query = query.Include(forma => forma.FormaPagamentoEntity);

            query = query.Include(pedido => pedido.PedidoEntity);

            return query;
        }


    }
}

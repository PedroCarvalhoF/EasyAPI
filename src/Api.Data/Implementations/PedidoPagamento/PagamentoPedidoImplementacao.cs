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
        }
        private static IQueryable<PagamentoPedidoEntity> Include(IQueryable<PagamentoPedidoEntity>? query)
        {

            query = query.Include(forma => forma.FormaPagamentoEntity);

            query = query.Include(pedido => pedido.PedidoEntity);

            return query;
        }

        public async Task<IEnumerable<PagamentoPedidoEntity>> GetAll()
        {
            try
            {
                IQueryable<PagamentoPedidoEntity> query = _dataset.AsNoTracking();

                query = Include(query);

                var entites = await query.ToArrayAsync();

                return entites;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<PagamentoPedidoEntity> Get(Guid idPagamento)
        {
            try
            {
                IQueryable<PagamentoPedidoEntity> query = _dataset.AsNoTracking();

                query = Include(query);

                query = query.Where(pgt => pgt.Id == idPagamento);

                var entity = await query.SingleOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PagamentoPedidoEntity>> GetByIdPedido(Guid idPedido)
        {
            try
            {
                IQueryable<PagamentoPedidoEntity> query = _dataset.AsNoTracking();

                query = Include(query);

                query = query.Where(pgt => pgt.PedidoEntity.Id == idPedido);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

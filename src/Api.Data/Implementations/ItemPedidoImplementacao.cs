using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.ItensPedido;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Implementations
{
    public class ItemPedidoImplementacao : BaseRepository<ItemPedidoEntity>, IItemPedidoRepository
    {
        private readonly DbSet<ItemPedidoEntity> _dataset;
        public ItemPedidoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<ItemPedidoEntity>();
        }

        public async Task<ItemPedidoEntity> GetByIdItemPedido(Guid idItemPedido)
        {
            try
            {
                IQueryable<ItemPedidoEntity> query = _context.ItensPedidos.AsNoTracking();

                query = query.Include(pedido => pedido.PedidoEntity).ThenInclude(pdv => pdv.PontoVendaEntity);
                query = query.Include(produto => produto.ProdutoEntity).ThenInclude(cat_prod => cat_prod.CategoriaProdutoEntity);


                query = query.Where(item => item.Id.Equals(idItemPedido));



                return await query.SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ItemPedidoEntity>> GetByIdProduto(Guid idProduto, bool fullConsulta)
        {
            try
            {
                IQueryable<ItemPedidoEntity> query = _context.ItensPedidos.AsNoTracking();

                if (fullConsulta)
                {
                    query = query.Include(pedido => pedido.PedidoEntity).ThenInclude(pdv => pdv.PontoVendaEntity);
                    query = query.Include(produto => produto.ProdutoEntity).ThenInclude(cat_prod => cat_prod.CategoriaProdutoEntity);
                }


                query = query.Where(item => item.ProdutoEntityId.Equals(idProduto));

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ItemPedidoEntity>> SelectAsync(Expression<Func<ItemPedidoEntity, bool>> funcao, bool fullConsulta = false)
        {
            try
            {
                IQueryable<ItemPedidoEntity> query = _context.ItensPedidos.AsNoTracking();
                if (fullConsulta)
                {
                    query = query.Include(pedido => pedido.PedidoEntity).ThenInclude(pdv => pdv.PontoVendaEntity);
                    query = query.Include(produto => produto.ProdutoEntity).ThenInclude(cat_prod => cat_prod.CategoriaProdutoEntity);
                }

                query = query.Where(funcao);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

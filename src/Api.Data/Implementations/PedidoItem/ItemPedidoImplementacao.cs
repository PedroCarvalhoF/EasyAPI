using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.ItensPedido;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PedidoItem
{
    public class ItemPedidoImplementacao : BaseRepository<ItemPedidoEntity>, IItemPedidoRepository
    {
        private readonly DbSet<ItemPedidoEntity> _dtSet;
        public ItemPedidoImplementacao(MyContext context) : base(context)
        {
            _dtSet = context.Set<ItemPedidoEntity>();
            _dtSet.AsNoTracking();
        }
        public async Task<IEnumerable<ItemPedidoEntity>> GetAll()
        {
            try
            {
                IQueryable<ItemPedidoEntity>? query = _dtSet.AsNoTracking();

                query = Include(query);

                //query = query.Where();

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ItemPedidoEntity> Get(Guid id)
        {
            try
            {
                IQueryable<ItemPedidoEntity>? query = _dtSet.AsNoTracking();

                query = Include(query);

                query = query.Where(item => item.Id.Equals(id));

                var entity = await query.FirstOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<ItemPedidoEntity> GetByIdPedido(Guid idPedido)
        {
            try
            {
                IQueryable<ItemPedidoEntity>? query = _dtSet.AsNoTracking();

                query = Include(query);

                query = query.Where(item => item.PedidoEntityId.Equals(idPedido));

                var entity = await query.FirstOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private IQueryable<ItemPedidoEntity> Include(IQueryable<ItemPedidoEntity>? query)
        {
            // produto
            query = query.Include(produto => produto.ProdutoEntity)
                          .ThenInclude(cat_prd => cat_prd.CategoriaProdutoEntity);

            query = query.Include(produto => produto.ProdutoEntity)
                          .ThenInclude(med => med.ProdutoMedidaEntity);

            query = query.Include(produto => produto.ProdutoEntity)
                          .ThenInclude(tp => tp.ProdutoTipoEntity);

            //pedido
            query = query.Include(pedido => pedido.PedidoEntity)
                          .ThenInclude(sit_ped => sit_ped.SituacaoPedidoEntity);

            query = query.Include(pedido => pedido.PedidoEntity)
                          .ThenInclude(pdv => pdv.PontoVendaEntity).ThenInclude(per => per.PeriodoPontoVendaEntity);

            //usuario
            query = query.Include(usuario => usuario.UsuarioPontoVendaEntity);

            return query;
        }
    }
}
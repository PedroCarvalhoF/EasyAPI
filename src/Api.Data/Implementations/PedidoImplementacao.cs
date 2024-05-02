using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.Pedido;
using Domain.Enuns;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Implementations
{
    public class PedidoImplementacao : BaseRepository<PedidoEntity>, IPedidoRepository
    {
        private readonly DbSet<PedidoEntity> _dataset;
        public PedidoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<PedidoEntity>();
        }

        public async Task<IEnumerable<PedidoEntity>> Get(SituacaoPedidoEnum situacaoPedido)
        {
            try
            {
                return null;
                //IQueryable<PedidoEntity> query = _context.Pedidos.AsNoTracking();

                //query = QueryPedidoEntity(query);

                //PedidoEntity[] resut = await query.ToArrayAsync();
                //return resut;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PedidoEntity>> SelectAsync(Expression<Func<PedidoEntity, bool>> funcao, bool inlude = true)
        {
            try
            {
                return null;
                //IQueryable<PedidoEntity> query = _context.Pedidos.AsNoTracking();
                //if (inlude)
                //{
                //    query = QueryPedidoEntity(query);
                //}

                //query = query.Where(funcao);
                //PedidoEntity[] entities = await query.ToArrayAsync();
                //return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static IQueryable<PedidoEntity> QueryPedidoEntity(IQueryable<PedidoEntity> query)
        {
            //PONTO DE VENDA
            query = query.Include(ped => ped.PontoVendaEntity);

            //ITENS DO PEDIDO
            query = query.Include(item => item.ItemPedidoEntities).
                          ThenInclude(prod => prod.ProdutoEntity).ThenInclude(cat_prod => cat_prod.CategoriaProdutoEntity);

            //CATEGORIA DE PREÇO DO PEDIDO
            query = query.Include(cat_preco => cat_preco.CategoriaPrecoEntity);

            //PAGAMENTO DO PEDIDO
            query = query.Include(pgt => pgt.PagamentoPedidoEntities).ThenInclude(f_pgt => f_pgt.FormaPagamentoEntity);
            return query;
        }
    }
}

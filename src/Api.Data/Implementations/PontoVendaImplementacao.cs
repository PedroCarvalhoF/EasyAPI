using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.PontoVenda;
using Domain.Dtos.PontoVendaDtos;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Implementations
{
    public class PontoVendaImplementacao : BaseRepository<PontoVendaEntity>, IPontoVendaRepository
    {
        private readonly DbSet<PontoVendaEntity> _dataset;

        public PontoVendaImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<PontoVendaEntity>();
        }

        public async Task<IEnumerable<PontoVendaEntity>> ConsultarPdvsById(List<Guid> idsPdvs)
        {
            try
            {
                IQueryable<PontoVendaEntity>? query = _context.PontosVendas;

                query = query
                    .Where(pdv => idsPdvs.Contains(pdv.Id))
                    .Select(pdv => pdv);

                //query = query?.Include(ped => ped.PedidoEntity);

                query = query?.Include(ped => ped.PedidoEntities)
                              .ThenInclude(item_pedido => item_pedido.ItemPedidoEntities);


                query = query?.Include(ped => ped.PedidoEntities)
                             .ThenInclude(item_pedido => item_pedido.ItemPedidoEntities)
                             .ThenInclude(produto => produto.ProdutoEntity)
                             .ThenInclude(cat_produto => cat_produto.CategoriaProdutoEntity);




                //categoria preço pedido

                query = query?.Include(pedido => pedido.PedidoEntities)
                             .ThenInclude(cat_preco => cat_preco.CategoriaPrecoEntity);

                //Pagamento Pedido

                query = query?.Include(ped => ped.PedidoEntities)
                             .ThenInclude(pgt => pgt.PagamentoPedidoEntities)
                             .ThenInclude(forma_pgt => forma_pgt.FormaPagamentoEntity);

                PontoVendaEntity[] entities = await query.AsNoTracking().ToArrayAsync();


                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<IEnumerable<PontoVendaEntity>> GetPontoVenda(Expression<Func<PontoVendaEntity, bool>> funcao, bool inlude = true)
        {
            IQueryable<PontoVendaEntity>? query = _context.PontosVendas;
            query = query?.Where(funcao);

            if (inlude)
            {
                //item pedido
                query = query?.Include(ped => ped.PedidoEntities)
                             .ThenInclude(item_pedido => item_pedido.ItemPedidoEntities)
                             .ThenInclude(produto => produto.ProdutoEntity)
                             .ThenInclude(cat_produto => cat_produto.CategoriaProdutoEntity);

                //categoria preço pedido

                query = query?.Include(pedido => pedido.PedidoEntities)
                             .ThenInclude(cat_preco => cat_preco.CategoriaPrecoEntity);

                //Pagamento Pedido

                query = query?.Include(ped => ped.PedidoEntities)
                             .ThenInclude(pgt => pgt.PagamentoPedidoEntities)
                             .ThenInclude(forma_pgt => forma_pgt.FormaPagamentoEntity);
            }

            PontoVendaEntity[] entities = await query.AsNoTracking().ToArrayAsync();

            return entities;
        }



        public async Task<IEnumerable<PontoVendaEntity>> ConsultarPontoVendaByData(PdvGetByData pdvGetByData)
        {
            try
            {
                IQueryable<PontoVendaEntity>? query = _context.PontosVendas.AsNoTracking();

                query = query
               .Where(pdv => pdv.CreateAt >= pdvGetByData.DataInicial.Date && pdv.CreateAt <= pdvGetByData.DataFinal.Date.AddDays(1));

                query = query?.Include(ped => ped.PedidoEntities)
                         .ThenInclude(item_pedido => item_pedido.ItemPedidoEntities)
                         .ThenInclude(produto => produto.ProdutoEntity)
                         .ThenInclude(cat_produto => cat_produto.CategoriaProdutoEntity);

                //categoria preço pedido

                query = query?.Include(pedido => pedido.PedidoEntities)
                             .ThenInclude(cat_preco => cat_preco.CategoriaPrecoEntity);

                //Pagamento Pedido

                query = query?.Include(ped => ped.PedidoEntities)
                             .ThenInclude(pgt => pgt.PagamentoPedidoEntities)
                             .ThenInclude(forma_pgt => forma_pgt.FormaPagamentoEntity);


                return await query.AsNoTracking().ToArrayAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }






        public async Task<IEnumerable<PontoVendaEntity>> InfoDashPdvsByPeriodo(PdvGetByData filtroConsultaPdvDashDto)
        {
            IQueryable<PontoVendaEntity>? query = _context.PontosVendas;

            query = query
                .Where(pdv => pdv.CreateAt >= filtroConsultaPdvDashDto.DataInicial.Date && pdv.CreateAt <= filtroConsultaPdvDashDto.DataFinal.Date);

            query = query?.Include(ped => ped.PedidoEntities)
                         .ThenInclude(item_pedido => item_pedido.ItemPedidoEntities)
                         .ThenInclude(produto => produto.ProdutoEntity)
                         .ThenInclude(cat_produto => cat_produto.CategoriaProdutoEntity);

            //categoria preço pedido

            query = query?.Include(pedido => pedido.PedidoEntities)
                         .ThenInclude(cat_preco => cat_preco.CategoriaPrecoEntity);

            //Pagamento Pedido

            query = query?.Include(ped => ped.PedidoEntities)
                         .ThenInclude(pgt => pgt.PagamentoPedidoEntities)
                         .ThenInclude(forma_pgt => forma_pgt.FormaPagamentoEntity);


            return await query.AsNoTracking().ToArrayAsync();
        }

        #region Dash Ponto Venda Versao V2

        public async Task<IEnumerable<PontoVendaEntity>> GetByIdsPdvs(List<Guid> idsPdvs)
        {
            try
            {
                IQueryable<PontoVendaEntity>? query = _context.PontosVendas;

                query = query?
                    .Where(pdv => idsPdvs.Contains(pdv.Id))
                    .Select(pdv => pdv);

                query = query?.Include(ped => ped.PedidoEntities)
                       .ThenInclude(item_pedido => item_pedido.ItemPedidoEntities)
                       .ThenInclude(produto => produto.ProdutoEntity)
                       .ThenInclude(cat_produto => cat_produto.CategoriaProdutoEntity);

                //categoria preço pedido

                query = query?.Include(pedido => pedido.PedidoEntities)
                             .ThenInclude(cat_preco => cat_preco.CategoriaPrecoEntity);

                //Pagamento Pedido

                query = query?.Include(ped => ped.PedidoEntities)
                             .ThenInclude(pgt => pgt.PagamentoPedidoEntities)
                             .ThenInclude(forma_pgt => forma_pgt.FormaPagamentoEntity);



                PontoVendaEntity[] entities = await query?.AsNoTracking().ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}

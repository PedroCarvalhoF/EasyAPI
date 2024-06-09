using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.PontoVenda;
using Domain.Dtos.PontoVenda.Filtros;
using Domain.Interfaces.Repository.PontoVenda;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PontoVenda
{
    public class PontoVendaImplementacao : BaseRepository<PontoVendaEntity>, IPontoVendaRepository
    {
        private readonly DbSet<PontoVendaEntity> _dbSet;

        public PontoVendaImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<PontoVendaEntity>();

        }
        public async Task<IEnumerable<PontoVendaEntity>> GetPdvs(bool include = false)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            if (include)
            {
                query = FullIncludes(query);
            }
            else
            {
                query = Includes(query);
            }


            var result = await query.ToArrayAsync();

            return result;
        }
        public async Task<PontoVendaEntity> GetByIdPdv(Guid pdvId, bool include = false)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            if (include)
            {
                query = FullIncludes(query);
            }
            else
            {
                query = Includes(query);
            }


            query = query.Where(pdv => pdv.Id.Equals(pdvId));

            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<PontoVendaEntity>> GetByIdPerfilUsuario(Guid idUser, bool include = false)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            if (include)
            {
                query = FullIncludes(query);
            }
            else
            {
                query = Includes(query);
            }


            query = query.Where(pdv => pdv.UserPdvUsingId.Equals(idUser));

            var result = await query.ToArrayAsync();
            return result;
        }

        public async Task<IEnumerable<PontoVendaEntity>> AbertosFechados(bool abertoFechado, bool include = false)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            if (include)
            {
                query = FullIncludes(query);
            }
            else
            {
                query = Includes(query);
            }


            query = query.Where(pdv => pdv.AbertoFechado == abertoFechado);

            var result = await query.ToArrayAsync();
            return result;
        }
        public async Task<IEnumerable<PontoVendaEntity>> FiltrarByData(PontoVendaDtoFiltrarData data, bool include = false)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            query = query.Where(pdv => pdv.CreateAt.Value.Date >= data.DataInicial && pdv.CreateAt.Value.Date <= data.DataFinal);

            if (include)
            {
                query = FullIncludes(query);
            }
            else
            {
                query = Includes(query);
            }


            var result = await query.ToArrayAsync();

            return result;
        }
        private IQueryable<PontoVendaEntity> FullIncludes(IQueryable<PontoVendaEntity> query)
        {

            query = query.Include(userAbriu => userAbriu.UserPdvCreate).ThenInclude(u => u.User)
                         .Include(userPDV => userPDV.UserPdvUsing).ThenInclude(u => u.User)
                         .Include(periodo => periodo.PeriodoPontoVendaEntity);

            query = query.Include(pedido => pedido.PedidoEntities).ThenInclude(cat_preco => cat_preco.CategoriaPrecoEntity).Include(sit => sit.PedidoEntities).ThenInclude(sit => sit.SituacaoPedidoEntity).Include(userReg => userReg.PedidoEntities).ThenInclude(userReg => userReg.UserRegistro).ThenInclude(userReg => userReg.User);

            query = query.Include(pedido => pedido.PedidoEntities).ThenInclude(itens_ped => itens_ped.ItensPedidoEntities).ThenInclude(prod => prod.ProdutoEntity);


            query = query.Include(pdv => pdv.PedidoEntities).ThenInclude(pgt => pgt.PagamentoPedidoEntities).ThenInclude(forma => forma.FormaPagamentoEntity);

            return query;
        }

        private IQueryable<PontoVendaEntity> Includes(IQueryable<PontoVendaEntity> query)
        {

            query = query.Include(userAbriu => userAbriu.UserPdvCreate).ThenInclude(u => u.User)
                         .Include(userPDV => userPDV.UserPdvUsing).ThenInclude(u => u.User)
                         .Include(periodo => periodo.PeriodoPontoVendaEntity);

            return query;
        }


    }
}
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
        public async Task<IEnumerable<PontoVendaEntity>> GetPdvs()
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            query = Includes(query);

            var result = await query.ToArrayAsync();

            return result;
        }
        public async Task<PontoVendaEntity> GetByIdPdv(Guid pdvId)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            query = Includes(query);

            query = query.Where(pdv => pdv.Id.Equals(pdvId));

            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<PontoVendaEntity>> GetByIdPerfilUsuario(Guid idUser)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            query = Includes(query);

            query = query.Where(pdv => pdv.UserPdvUsingId.Equals(idUser));

            var result = await query.ToArrayAsync();
            return result;
        }

        public async Task<IEnumerable<PontoVendaEntity>> AbertosFechados(bool abertoFechado)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            query = Includes(query);

            query = query.Where(pdv => pdv.AbertoFechado == abertoFechado);

            var result = await query.ToArrayAsync();
            return result;
        }
        public async Task<IEnumerable<PontoVendaEntity>> FiltrarByData(PontoVendaDtoFiltrarData data)
        {
            IQueryable<PontoVendaEntity> query = _dbSet.AsNoTracking();

            query = query.Where(pdv => pdv.CreateAt.Value.Date >= data.DataInicial && pdv.CreateAt.Value.Date <= data.DataFinal);

            query = Includes(query);

            var result = await query.ToArrayAsync();

            return result;
        }
        private IQueryable<PontoVendaEntity> Includes(IQueryable<PontoVendaEntity> query)
        {

            query = query.Include(userAbriu => userAbriu.UserPdvCreate).ThenInclude(u => u.User)
                         .Include(userPDV => userPDV.UserPdvUsing).ThenInclude(u => u.User)
                         .Include(periodo => periodo.PeriodoPontoVendaEntity);

            query = query.Include(pdv => pdv.PedidoEntities).ThenInclude(cat_preco => cat_preco.CategoriaPrecoEntity);
            query = query.Include(pdv => pdv.PedidoEntities).ThenInclude(item => item.ItensPedidoEntities).ThenInclude(prod => prod.ProdutoEntity);

            query = query.Include(pdv => pdv.PedidoEntities).ThenInclude(pgt => pgt.PagamentoPedidoEntities).ThenInclude(forma => forma.FormaPagamentoEntity);

            return query;
        }


    }
}
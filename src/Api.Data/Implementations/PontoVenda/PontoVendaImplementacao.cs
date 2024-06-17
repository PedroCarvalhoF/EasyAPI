using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.PontoVenda;
using Data.Query;
using Domain.Dtos.PontoVenda.Filtros;
using Domain.Interfaces.Repository.PontoVenda;
using Domain.UserIdentity.Masters;
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
        public async Task<IEnumerable<PontoVendaEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);

                query = FullIncludes(query);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<PontoVendaEntity> GetById(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users).Where(pdv => pdv.Id == id);

                query = FullIncludes(query);

                var entity = await query.SingleOrDefaultAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Exists(PontoVendaEntity entityPdv, UserMasterUserDtoCreate users)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private IQueryable<PontoVendaEntity> FullIncludes(IQueryable<PontoVendaEntity> query)
        {
            query = query.Include(userAbriu => userAbriu.UserPdvCreate)
                         .ThenInclude(u => u.UserPdv)
                         .Include(userPDV => userPDV.UserPdvUsing)
                         .ThenInclude(u => u.UserPdv)
                         .Include(periodo => periodo.PeriodoPontoVendaEntity);

            query = query.Include(pedido => pedido.PedidoEntities)
                         .ThenInclude(p => p.CategoriaPrecoEntity)
                         .Include(pedido => pedido.PedidoEntities)
                         .ThenInclude(p => p.SituacaoPedidoEntity)
                         .Include(pedido => pedido.PedidoEntities)
                         .ThenInclude(p => p.UserRegistro)
                         .ThenInclude(userReg => userReg.UserPdv);

            query = query.Include(pedido => pedido.PedidoEntities)
                         .ThenInclude(p => p.ItensPedidoEntities)
                         .ThenInclude(itens_ped => itens_ped.ProdutoEntity);

            query = query.Include(pdv => pdv.PedidoEntities)
                         .ThenInclude(p => p.PagamentoPedidoEntities)
                         .ThenInclude(pgt => pgt.FormaPagamentoEntity);

            return query;
        }
    }
}
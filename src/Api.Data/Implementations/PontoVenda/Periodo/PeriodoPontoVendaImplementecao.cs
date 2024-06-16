using Api.Data.Context;
using Api.Data.Repository;
using Data.Query;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PontoVenda.Periodo
{
    public class PeriodoPontoVendaImplementecao : BaseRepository<PeriodoPontoVendaEntity>, IPeriodoPontoVendaRepository
    {
        private readonly DbSet<PeriodoPontoVendaEntity> _dbSet;
        public PeriodoPontoVendaImplementecao(MyContext context) : base(context)
        {
            _dbSet = context.Set<PeriodoPontoVendaEntity>();
        }
        public async Task<IEnumerable<PeriodoPontoVendaEntity>> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Exists(PeriodoPontoVendaEntity entity, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.FiltroUserMasterCliente(users);

                var entities = await query.AnyAsync(t => t.DescricaoPeriodo.ToLower() == entity.DescricaoPeriodo.ToLower());

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PeriodoPontoVendaEntity> GetById(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var query = _dbSet.AsNoTracking();
                query = query.FiltroUserMasterCliente(users).Where(t => t.Id == id);

                var entity = await query.SingleOrDefaultAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

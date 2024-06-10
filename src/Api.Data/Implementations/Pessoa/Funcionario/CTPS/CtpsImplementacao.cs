using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Funcionario.CTPS;
using Domain.Interfaces.Repository.Pessoa.Funcionario.CTPS;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoa.Funcionario.CTPS
{
    public class CtpsImplementacao : BaseRepository<CtpsEntity>, ICtpsRepository
    {
        private readonly DbSet<CtpsEntity> _dbSet;
        public CtpsImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<CtpsEntity>();
        }

        public async Task<IEnumerable<CtpsEntity>> GetAll()
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CtpsEntity> GetByIdCtps(Guid ctpsId)
        {
            try
            {
                var query = _dbSet.AsNoTracking();

                query = query.Where(ct => ct.Id == ctpsId);

                var entity = await query.SingleAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

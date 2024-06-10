using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.Pessoa.Contato;
using Domain.Interfaces.Repository.Pessoa.Contato;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.Pessoas.Contato
{
    public class ContatoImplementacao : BaseRepository<ContatoEntity>, IContatoRepository
    {
        private readonly DbSet<ContatoEntity> _dbSet;
        public ContatoImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<ContatoEntity>();
        }

        private IQueryable<ContatoEntity> FullInclude(IQueryable<ContatoEntity> query)
        {
            return query;
        }

        public async Task<IEnumerable<ContatoEntity>> GetAllContatos()
        {
            try
            {
                IQueryable<ContatoEntity> query = _dbSet.AsNoTracking();

                query = FullInclude(query);

                var entities = await query.ToArrayAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContatoEntity> GetByContatoId(Guid idContato)
        {
            try
            {
                IQueryable<ContatoEntity> query = _dbSet.AsNoTracking();

                query = FullInclude(query);

                query = query.Where(c => c.Id == idContato);

                var entities = await query.SingleOrDefaultAsync();

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

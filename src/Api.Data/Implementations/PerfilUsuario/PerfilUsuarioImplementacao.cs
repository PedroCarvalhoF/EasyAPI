using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.UsuarioSistema;
using Domain.Interfaces.Repository.PerfilUsuario;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PerfilUsuario
{
    public class PerfilUsuarioImplementacao : BaseRepository<PerfilUsuarioEntity>, IPerfilUsuarioRepository
    {
        private readonly DbSet<PerfilUsuarioEntity> _dbSet;
        public PerfilUsuarioImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<PerfilUsuarioEntity>();
            _dbSet.AsNoTracking();
        }

        public async Task<IEnumerable<PerfilUsuarioEntity>> GetAll()
        {
            try
            {
                IQueryable<PerfilUsuarioEntity> query = _dbSet;

                query = query.Where(p => p.Habilitado.Equals(true));

                query = Includes(query);

                return await query.ToArrayAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PerfilUsuarioEntity> GetPerfilUsuarioId(Guid id)
        {
            IQueryable<PerfilUsuarioEntity> query = _dbSet;

            query = query.Where(user => user.Id.Equals(id));

            query = Includes(query);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<PerfilUsuarioEntity>> GetPerfilUsuarioName(string name)
        {
            IQueryable<PerfilUsuarioEntity> query = _dbSet;

            query = query.Where(user => user.Nome.ToLower().Equals(name.ToLower()));

            query = Includes(query);

            return await query.ToArrayAsync();
        }

        private IQueryable<PerfilUsuarioEntity> Includes(IQueryable<PerfilUsuarioEntity> query)
        {
            return query;
        }
    }

}

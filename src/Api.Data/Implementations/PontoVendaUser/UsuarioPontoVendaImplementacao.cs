using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.PontoVendaUser;
using Domain.Interfaces.Repository.PontoVendaUser;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations.PontoVendaUser
{
    public class UsuarioPontoVendaImplementacao : BaseRepository<UsuarioPontoVendaEntity>, IUsuarioPontoVendaRepository
    {
        private readonly DbSet<UsuarioPontoVendaEntity> _dbSet;
        public UsuarioPontoVendaImplementacao(MyContext context) : base(context)
        {
            _dbSet = context.Set<UsuarioPontoVendaEntity>();
            _dbSet.AsNoTracking();
        }
        public async Task<IEnumerable<UsuarioPontoVendaEntity>> GetAll()
        {
            try
            {
                IQueryable<UsuarioPontoVendaEntity> query = _dbSet.AsNoTracking();

                query = Include(query);

                var entities = await query.ToArrayAsync();

                return entities;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<UsuarioPontoVendaEntity> Get(Guid id) 
        {
            try
            {
                IQueryable<UsuarioPontoVendaEntity> query = _dbSet.AsNoTracking();

                query = Include(query);

                query = query.Where(u => u.Id == id);

                var entity = await query.FirstOrDefaultAsync();

                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<UsuarioPontoVendaEntity> GetByIdUser(Guid userId)
        {
            try
            {
                IQueryable<UsuarioPontoVendaEntity> query = _dbSet.AsNoTracking();

                query = Include(query);

                query = query.Where(u => u.User!.Id == userId);

                var entity = await query.FirstOrDefaultAsync();

                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private IQueryable<UsuarioPontoVendaEntity> Include(IQueryable<UsuarioPontoVendaEntity> query)
        {
            try
            {
                query = query.Include(pdv => pdv.User);
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

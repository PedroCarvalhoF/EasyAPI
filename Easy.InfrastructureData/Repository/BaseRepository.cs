using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        private IQueryable<T> ApplyFilter(IQueryable<T> query, FiltroBase users)
        {
            return query.Where(e => e.UserMasterClienteIdentityId == users.clienteId);
        }

        public async Task<T> InsertAsync(T item)
        {
            await _dataset.AddAsync(item);            
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            _dataset.Update(item);          
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (result == null)
            {
                return false;
            }
            _dataset.Remove(result);
          
            return true;
        }

        public async Task<T> SelectAsync(Guid id, FiltroBase users)
        {
            return await ApplyFilter(_dataset.AsNoTracking(), users)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync(FiltroBase users)
        {
            return await ApplyFilter(_dataset.AsNoTracking(), users).ToListAsync();
        }

        public async Task<bool> ExistAsync(Guid id, FiltroBase users)
        {
            return await ApplyFilter(_dataset, users).AnyAsync(p => p.Id.Equals(id));
        }
    }
}

using Easy.Domain.Intefaces.Repository;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dataset;

        public RepositoryGeneric(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
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
            var entity = await _dataset.FindAsync(id);
            if (entity == null) return false;
            _dataset.Remove(entity);
            return true;
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

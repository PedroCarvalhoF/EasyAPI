using Api.Data.Context;
using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
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

        public async Task<bool> DeleteGenericAsync(Guid id)
        {
            var entity = await _dataset.FindAsync(id);
            if (entity == null) return false;

            _dataset.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<int> DeleteGenericAsync(IEnumerable<T> items)
        {
            _dataset.RemoveRange(items);
            return await _context.SaveChangesAsync();
        }
        public async Task<T> InsertGenericAsync(T item)
        {
            await _dataset.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<int> InsertArrayGenericAsync(IEnumerable<T> entities)
        {
            await _dataset.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }
        public async Task<T> SelectGenericAsync(Guid id)
        {
            return await _dataset.FindAsync(id);
        }
        public async Task<IEnumerable<T>> SelectGenericAsync()
        {
            return await _dataset.AsNoTracking().ToArrayAsync();
        }
        public async Task<T> UpdateGenericAsync(T item)
        {
            _dataset.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}

using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
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
            try
            {
                await _dataset.AddAsync(item);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<T> UpdateAsync(T item, FiltroBase filtro)
        {
            try
            {
                var result = await SelectAsync(item.Id, filtro);
                item.DataCriacao(result.CreateAt);
                _context.Set<T>().Entry(result).CurrentValues.SetValues(item);
                _context.Update(item);
                return item;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<T>? SelectAsync(Guid id, FiltroBase users)
        {
            var result = 
                await ApplyFilter(_dataset.AsNoTracking(), users)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
                return null;

            return result;
        }
        public async Task<IEnumerable<T>> SelectAsync(FiltroBase users)
        {
            var result = await
                _dataset.FiltroCliente(users)
                .AsNoTracking()
                .ToArrayAsync();

            return result;           
        }
    }
}

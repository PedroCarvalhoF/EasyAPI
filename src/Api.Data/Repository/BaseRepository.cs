using Api.Data.Context;
using Api.Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }
        public async Task<T> InsertAsync(T item)
        {
            try
            {
                item.Id = Guid.NewGuid();
                item.CreateAt = DateTime.Now;
                item.UpdateAt = DateTime.Now;
                item.Habilitado = true;

                _dataset.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }
        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> items)
        {
            using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (T item in items)
                {
                    item.Id = Guid.NewGuid();
                    item.CreateAt = DateTime.Now;
                    item.Habilitado = true;
                }

                await _dataset.AddRangeAsync(items);
                var result = await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Falha ao inserir os itens. A transação foi revertida. Detalhes do erro: " + ex.Message);
            }

            return items;
        }
        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }
                item.CreateAt = result.CreateAt;
                item.UpdateAt = DateTime.Now;
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }
        public async Task<bool> DesabilitarHabilitar(Guid id)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                result.UpdateAt = DateTime.Now;
                result.Habilitado = false;

                _context.Update(result);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteAsync(IEnumerable<Guid> ids)
        {
            try
            {
                IQueryable<T> results = _dataset.Where(p => ids.Contains(p.Id));
                _dataset.RemoveRange(results);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteAsync(IEnumerable<T> itens)
        {
            try
            {
                List<T> itemsToRemove = _dataset.Where(p => itens.Contains(p)).ToList();
                _dataset.RemoveRange(itemsToRemove);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

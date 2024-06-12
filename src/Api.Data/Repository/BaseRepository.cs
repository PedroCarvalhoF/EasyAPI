using Api.Data.Context;
using Api.Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Data.Repository
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

        public async Task<IEnumerable<T>> SelectAsync(Guid? filtroId=null)
        {
            try
            {
                return await _dataset.Where(t => t.FiltroId == filtroId).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> SelectAsync(Guid id, Guid? filtroId = null)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id) && p.FiltroId == filtroId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ExistAsync(Guid id, Guid? filtroId = null)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id) && p.FiltroId == filtroId);
        }
        public async Task<T> InsertAsync(T item, Guid? filtroId)
        {
            try
            {
                item.Id = Guid.NewGuid();
                item.CreateAt = DateTime.Now;
                item.UpdateAt = DateTime.Now;
                item.Habilitado = true;
                item.FiltroId = filtroId;
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
        public async Task<int> InsertArrayAsync(IEnumerable<T> entity, Guid? filtroId = null)
        {
            try
            {
                foreach (var item in entity)
                {
                    if (item.Id == Guid.Empty)
                        item.Id = Guid.NewGuid();
                    item.CreateAt = DateTime.Now;
                    item.UpdateAt = DateTime.Now;
                    item.Habilitado = true;
                    item.FiltroId = filtroId;
                }

                _dataset.AddRange(entity);
                return await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> items, Guid? filtroId = null)
        {
            using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (T item in items)
                {
                    item.Id = Guid.NewGuid();
                    item.CreateAt = DateTime.Now;
                    item.Habilitado = true;
                    item.FiltroId = filtroId;
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
        public async Task<T> UpdateAsync(T item, Guid? filtroId = null)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id) && p.FiltroId == filtroId);
                if (result == null)
                {
                    return null;
                }
                item.CreateAt = result.CreateAt;
                item.UpdateAt = DateTime.Now;
                item.FiltroId = result.FiltroId;
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return item;
        }
        public async Task<bool> DesabilitarHabilitar(Guid id, Guid? filtroId = null)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id) && p.FiltroId == filtroId);
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
        public async Task<bool> DeleteAsync(Guid id, Guid? filtroId = null)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id) && p.FiltroId == filtroId);
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
        public async Task<int> DeleteAsync(IEnumerable<Guid> ids, Guid? filtroId = null)
        {
            try
            {
                IQueryable<T> results = _dataset.Where(p => ids.Contains(p.Id) && p.FiltroId == filtroId);
                _dataset.RemoveRange(results);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> DeleteAsync(IEnumerable<T> itens, Guid? filtroId = null)
        {
            try
            {
                List<T> itemsToRemove = _dataset.Where(p => itens.Contains(p) && p.FiltroId == filtroId).ToList();
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

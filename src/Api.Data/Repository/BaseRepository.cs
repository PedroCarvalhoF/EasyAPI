using Api.Data.Context;
using Api.Domain.Entities;
using Data.Query;
using Domain.Interfaces;
using Domain.UserIdentity.Masters;
using Domain.UserIdentity.MasterUsers;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<T>> SelectAsync(UserMasterUserDtoCreate? user = null)
        {
            try
            {
                return await _dataset.FiltroUserMasterCliente(user).ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar todos os itens: " + ex.Message);
            }
        }
        public async Task<T> SelectAsync(Guid id, UserMasterUserDtoCreate? user = null)
        {
            try
            {
                return await _dataset.FiltroUserMasterCliente(user).SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao selecionar item por ID: {id}. Detalhes: " + ex.Message);
            }
        }
        public async Task<bool> ExistAsync(Guid id, UserMasterUserDtoCreate? user = null)
        {
            try
            {
                return await _dataset.FiltroUserMasterCliente(user).AnyAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do item por ID: {id}. Detalhes: " + ex.Message);
            }
        }
        public async Task<T> InsertAsync(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            try
            {
                _dataset.Add(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao inserir item: " + ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir item: " + ex.Message);
            }
        }
        public async Task<int> InsertArrayAsync(IEnumerable<T> bases, UserMasterUserDtoCreate? user = null)
        {
            if (bases == null || !bases.Any()) throw new ArgumentException("A coleção não pode ser nula ou vazia", nameof(bases));

            try
            {

                _dataset.AddRange(bases);
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao inserir coleção de itens: " + ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir coleção de itens: " + ex.Message);
            }
        }
        public async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> items, UserMasterUserDtoCreate? user = null)
        {
            if (items == null || !items.Any()) throw new ArgumentException("A coleção não pode ser nula ou vazia", nameof(items));

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                await _dataset.AddRangeAsync(items);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return items;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Falha ao inserir os itens. A transação foi revertida. Detalhes do erro: " + ex.Message);
            }
        }
        public async Task<T> UpdateAsync(T item, UserMasterUserDtoCreate? user = null)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id == item.Id);
                if (result == null) return null;

                item.AtulizarData(result.CreateAt);
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar item: " + ex.Message);
            }
        }
        public async Task<bool> DesabilitarHabilitar(Guid id, UserMasterUserDtoCreate? user = null)
        {
            return false;

            //try
            //{
            //    var result = await _dataset.FiltroUserMasterCliente(user).SingleOrDefaultAsync(p => p.Id == id);
            //    if (result == null) return false;

            //    result.Desabilitar();

            //    _context.Update(result);
            //    await _context.SaveChangesAsync();

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
        public async Task<bool> DeleteAsync(Guid id, UserMasterUserDtoCreate? user = null)
        {
            try
            {
                var result = await _dataset.FiltroUserMasterCliente(user).SingleOrDefaultAsync(p => p.Id == id);
                if (result == null) return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar item com ID: {id}. Detalhes: " + ex.Message);
            }
        }
        public async Task<int> DeleteAsync(IEnumerable<Guid> ids, UserMasterUserDtoCreate? user = null)
        {
            return 0;

            //if (ids == null || !ids.Any()) throw new ArgumentException("A coleção de IDs não pode ser nula ou vazia", nameof(ids));

            //try
            //{
            //    var results = _dataset.FiltroUserMasterCliente(user).Where(p => ids.Contains(p.Id));
            //    _dataset.RemoveRange(results);
            //    return await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Erro ao deletar coleção de itens por IDs: " + ex.Message);
            //}
        }
        public async Task<int> DeleteAsync(IEnumerable<T> items, UserMasterUserDtoCreate? user = null)
        {
            if (items == null || !items.Any()) throw new ArgumentException("A coleção não pode ser nula ou vazia", nameof(items));

            try
            {
                var results = _dataset.FiltroUserMasterCliente(user).Where(p => items.Contains(p));
                _dataset.RemoveRange(results);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar coleção de itens: " + ex.Message);
            }
        }
    }
}


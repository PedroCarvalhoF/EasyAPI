using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Easy.InfrastructureData.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dataset = context.Set<T>();

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
                if (ex.InnerException is MySqlException mySqlEx && mySqlEx.Number == 1452) // 1452 é o código de erro MySQL para violação de chave estrangeira
                {
                    throw new Exception("Não foi possível inserir devido a falta de alguma dependencia.");
                }
                throw new Exception("Erro ao inserir item: " + ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir item: " + ex.Message);
            }
        }


        public async Task<T> UpdateAsync(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id == item.Id);
                if (result == null) throw new ArgumentException($"Registro não localizado para realizar alteração");

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar item: " + ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id == id);
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

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}


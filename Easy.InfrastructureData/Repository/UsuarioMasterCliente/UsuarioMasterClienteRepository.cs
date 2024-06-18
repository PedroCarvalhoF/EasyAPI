using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.UsuarioMasterCliente
{
    public class UsuarioMasterClienteRepository<T> : IUsuarioMasterClienteRepository<T> where T : UserMasterClienteEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dataset;
        public UsuarioMasterClienteRepository(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dataset = context.Set<T>();

        }

        public async Task<bool> Exists(Guid id)
        {
            try
            {
                var exists = await _dataset.AsNoTracking().AnyAsync(t => t.UserMasterId == id);
                return exists;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dataset.Include(u => u.UserMaster).Include(us => us.UsersMasterUsers).ThenInclude(u => u.UserMasterUser).AsNoTracking().ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar todos os itens: " + ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {

                return await _dataset.SingleAsync(t => t.UserMasterId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar todos os itens: " + ex.Message);
            }
        }
        public async Task<T> InsertAsync(T item)
        {
            try
            {
                var exists = await _dataset.AsNoTracking().SingleOrDefaultAsync(p => p.UserMasterId == item.UserMasterId);
                if (exists != null)
                    throw new ArgumentException("Usuário já é MASTER");

                _dataset.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar Master: " + ex.Message);
            }


        }
    }
}

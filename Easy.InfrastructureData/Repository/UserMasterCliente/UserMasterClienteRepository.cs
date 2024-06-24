using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.InfrastructureData.Context;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.UserMasterCliente
{
    public class UserMasterClienteRepository<T> : IUserMasterClienteRepository<T> where T : UserMasterClienteEntity
    {
        private readonly MyContext _context;

        public UserMasterClienteRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<T> CadastrarCliente(T create)
        {
            if (create == null)
                throw new ArgumentNullException(nameof(create));

            await _context.Set<T>().AddAsync(create);            
            return create;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToArrayAsync();
        }

        public async Task<T> GetById(Guid userClienteId)
        {
            return await _context.Set<T>().FindAsync(userClienteId);
        }
    }
}
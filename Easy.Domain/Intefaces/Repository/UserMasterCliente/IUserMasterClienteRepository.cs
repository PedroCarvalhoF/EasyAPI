using Easy.Domain.Entities.UserMasterCliente;

namespace Easy.Domain.Intefaces.Repository.UserMasterCliente
{
    public interface IUserMasterClienteRepository<T> where T : UserMasterClienteEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid userClienteId);
        Task<T> CadastrarCliente(T create);
    }
}

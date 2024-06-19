using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;

namespace Easy.Domain.Intefaces;

public interface IUnitOfWork
{
    IUsuarioMasterClienteRepository UsuarioMasterClienteRepository { get; }
    Task CommitAsync();
}

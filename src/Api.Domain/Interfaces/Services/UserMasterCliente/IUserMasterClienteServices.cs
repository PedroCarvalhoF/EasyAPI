using Domain.Dtos;

namespace Domain.Interfaces.Services.UserMasterCliente
{
    public interface IUserMasterClienteServices
    {
        Task<RequestResult> CadastrarUserMasterCliente(Guid userId);
        Task<RequestResult> GerarCredencialUsuario(Guid userIdCliente, Guid userForCredential);
        Task<RequestResult> GetUserMastersCliente();
        Task<RequestResult> GetUsersByMasterCliente(Guid userMasterClienteIdentityId);
    }
}

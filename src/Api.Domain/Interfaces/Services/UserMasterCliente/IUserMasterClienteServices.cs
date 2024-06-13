using Domain.Dtos;
using Domain.UserIdentity;

namespace Domain.Interfaces.Services.UserMasterCliente
{
    public interface IUserMasterClienteServices
    {
        Task<ResponseDto<List<UsuarioCadastroResponse>>> CadastrarUserMasterCliente(Guid userId);
        Task<ResponseDto<List<UsuarioCadastroResponse>>> GerarCredencialUsuario(Guid userIdCliente, Guid userForCredential);
    }
}

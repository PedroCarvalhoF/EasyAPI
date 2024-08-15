using Easy.Services.CQRS.PDV.UsuarioPdv.Commands;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;

namespace Easy.Services.Service.UsuarioPontoPdv;

public interface IUsuarioPdvService
{
    Task<RequestResult<UserDto>> UsuarioPdvCreateCommand(UsuarioPdvCommandCreate command);
    Task<RequestResult<UserDto>> HabilitarDesabilitarCommand(UsuarioPdvCommandHabilitarDesabilitar command);

}

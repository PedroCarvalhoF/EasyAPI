using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UsuarioPdv;
using Easy.Services.Service.UsuarioPontoPdv;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvCommandHabilitarDesabilitar : BaseCommands<UserDto>
{
    public required UsuarioPdvDtoHabilitarDesabilitar UsuarioPdvDto { get; set; }

    public class UsuarioPdvDesabilitarCommandHandler(IUsuarioPdvService _pdvServicesCommands) : IRequestHandler<UsuarioPdvCommandHabilitarDesabilitar, RequestResult<UserDto>>
    {
        public async Task<RequestResult<UserDto>> Handle(UsuarioPdvCommandHabilitarDesabilitar request, CancellationToken cancellationToken)
        {
            try
            {
                return await _pdvServicesCommands.HabilitarDesabilitarCommand(request);

            }
            catch (Exception ex)
            {

                return RequestResult<UserDto>.BadRequest(ex.Message);
            }
        }
    }
}

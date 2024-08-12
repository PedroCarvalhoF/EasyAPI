using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UsuarioPdv;
using Easy.Services.Service.UsuarioPontoPdv;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvCreateCommand : BaseCommands<UserDto>
{
    public required UsuarioPdvDtoCreate UsuarioPdv { get; set; }

    public class UsuarioPdvCreateCommandHandler(IUsuarioPdvService _usuarioPdvService) : IRequestHandler<UsuarioPdvCreateCommand, RequestResult<UserDto>>
    {
        public async Task<RequestResult<UserDto>> Handle(UsuarioPdvCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _usuarioPdvService.UsuarioPdvCreateCommand(request);
            }
            catch (Exception ex)
            {

                return RequestResult<UserDto>.BadRequest(ex.Message);
            }
        }
    }
}

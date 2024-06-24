using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Command;

public class UserMasterUserCreateCommand : IRequest<RequestResult>
{
    public FiltroBase Filtro { get; private set; }

    public UserMasterUserCreateCommand(FiltroBase filtro)
    {
        Filtro = filtro;
    }
}

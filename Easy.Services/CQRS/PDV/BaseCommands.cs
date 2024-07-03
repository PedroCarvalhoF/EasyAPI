using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV;

public abstract class BaseCommands : IRequest<RequestResult>
{
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;
}

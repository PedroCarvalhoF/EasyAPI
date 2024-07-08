using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS
{
    public class BaseCommands<T> : IRequest<RequestResult<T>> where T : class
    {
        FiltroBase? FiltroBase { get; set; }
        public void SetUsers(FiltroBase user)
            => FiltroBase = user;
        public FiltroBase GetFiltro()
           => FiltroBase ?? new FiltroBase(Guid.Empty, Guid.Empty);
    }
}

using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries;

public class GetPeriodoPdvByIdQuery : BaseCommands
{
    public Guid Id { get; set; }

    public class GetPeriodoPdvByIdQueryHandler : IRequestHandler<GetPeriodoPdvByIdQuery, RequestResult>
    {       
        public Task<RequestResult> Handle(GetPeriodoPdvByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

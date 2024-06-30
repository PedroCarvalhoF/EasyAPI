using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries;

public class GetPeriodoPdvByIdQuery : BaseCommands
{
    public Guid Id { get; set; }

    public class GetPeriodoPdvByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPeriodoPdvByIdQuery, RequestResult>
    {
        public async Task<RequestResult> Handle(GetPeriodoPdvByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var periodoEntity = await _repository.PeriodoPdvRepository.SelectAsync(request.Id, request.GetFiltro());
                return new RequestResult().Ok(periodoEntity);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

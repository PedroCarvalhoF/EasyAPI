using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries;

public class GetPeriodoPdvByIdQuery : BaseCommandsForUpdate
{
    public Guid Id { get; set; }

    public class GetPeriodoPdvByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPeriodoPdvByIdQuery, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetPeriodoPdvByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var periodoEntity = await _repository.PeriodoPdvRepository.SelectAsync(request.Id, request.GetFiltro());
                return new RequestResultForUpdate().Ok(periodoEntity);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

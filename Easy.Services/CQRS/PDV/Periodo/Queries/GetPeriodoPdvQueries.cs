using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries
{
    public class GetPeriodoPdvQueries : BaseCommandsForUpdate
    {
        public class GetPeriodoPdvQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetPeriodoPdvQueries, RequestResultForUpdate>
        {
            public async Task<RequestResultForUpdate> Handle(GetPeriodoPdvQueries request, CancellationToken cancellationToken)
            {
                try
                {
                    var periodosPdvsEntities = await _repository.PeriodoPdvRepository.SelectAsync(request.GetFiltro());
                    return new RequestResultForUpdate().Ok(periodosPdvsEntities);
                }
                catch (Exception ex)
                {

                    return new RequestResultForUpdate().BadRequest(ex.Message);
                }
            }
        }
    }
}

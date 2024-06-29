using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries
{
    public class GetPeriodoPdvQueries : BaseCommands
    {
        public class GetPeriodoPdvQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetPeriodoPdvQueries, RequestResult>
        {
            public async Task<RequestResult> Handle(GetPeriodoPdvQueries request, CancellationToken cancellationToken)
            {
                try
                {
                    var periodosPdvsEntities = await _repository.PeriodoPdvRepository.SelectAsync(request.GetFiltro());
                    return new RequestResult().Ok(periodosPdvsEntities);
                }
                catch (Exception ex)
                {

                    return new RequestResult().BadRequest(ex.Message);
                }
            }
        }
    }
}

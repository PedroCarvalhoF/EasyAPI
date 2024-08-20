using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries
{
    public class GetPeriodoPdvQueries : BaseCommands<IEnumerable<PeriodoPdvDto>>
    {
        public class GetPeriodoPdvQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetPeriodoPdvQueries, RequestResult<IEnumerable<PeriodoPdvDto>>>
        {
            public async Task<RequestResult<IEnumerable<PeriodoPdvDto>>> Handle(GetPeriodoPdvQueries request, CancellationToken cancellationToken)
            {
                try
                {
                    var periodosPdvsEntities = await _repository.PeriodoPdvRepository.SelectAsync(request.GetFiltro());
                    var dtos = DtoMapper.ParcePeriodoPdvDto(periodosPdvsEntities);
                    return RequestResult<IEnumerable<PeriodoPdvDto>>.Ok(dtos);
                }
                catch (Exception ex)
                {
                    return RequestResult<IEnumerable<PeriodoPdvDto>>.BadRequest(ex.Message);
                }
            }
        }
    }
}

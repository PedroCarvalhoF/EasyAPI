using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries
{
    public class GetPeriodoPdvFilterCommand : BaseCommands<IEnumerable<PeriodoPdvDto>>
    {
        public required PeriodoPdvEntityFilter PeriodoPdvEntityFilter { get; set; }
        public class GetPeriodoPdvFiltersHandler(IUnitOfWork _repository) : IRequestHandler<GetPeriodoPdvFilterCommand, RequestResult<IEnumerable<PeriodoPdvDto>>>
        {
            public async Task<RequestResult<IEnumerable<PeriodoPdvDto>>> Handle(GetPeriodoPdvFilterCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var filtro = request.GetFiltro();
                    var periodosEntities = await _repository.PeriodoPdvRepository.SelectAsync(request.PeriodoPdvEntityFilter, filtro);
                    var dtos = DtoMapper.ParcePeriodoPdvDto(periodosEntities);

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

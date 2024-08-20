using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Queries;

public class GetPeriodoPdvByIdQuery : BaseCommands<PeriodoPdvDto>
{
    public required PeriodoPdvDtoRequestId PeriodoPdvDtoRequestId { get; set; }

    public class GetPeriodoPdvByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPeriodoPdvByIdQuery, RequestResult<PeriodoPdvDto>>
    {
        public async Task<RequestResult<PeriodoPdvDto>> Handle(GetPeriodoPdvByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var periodoEntity = await _repository.PeriodoPdvRepository.SelectAsync(request.PeriodoPdvDtoRequestId.IdPeriodo, request.GetFiltro());

                if (periodoEntity.Id == Guid.Empty)
                    return RequestResult<PeriodoPdvDto>.BadRequest("Período não localizado");

                var periodoDto = DtoMapper.ParcePeriodoPdvDto(periodoEntity);

                return RequestResult<PeriodoPdvDto>.Ok(periodoDto);
            }
            catch (Exception ex)
            {

                return RequestResult<PeriodoPdvDto>.BadRequest(ex.Message);
            }
            finally
            {
                _repository.FinalizarContexto();
            }
        }
    }
}

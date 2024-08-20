using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Commands;

public class PeriodoPdvHabilitarDesabilitarCommand : BaseCommands<PeriodoPdvDto>
{
    public required PeriodoPdvDtoRequestId PeriodoPdvDtoRequestId { get; set; }

    public class PeriodoPdvHabilitarDesabilitarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PeriodoPdvHabilitarDesabilitarCommand, RequestResult<PeriodoPdvDto>>
    {
        public async Task<RequestResult<PeriodoPdvDto>> Handle(PeriodoPdvHabilitarDesabilitarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var periodoEntity = await _repository.PeriodoPdvRepository.SelectAsync(request.PeriodoPdvDtoRequestId.IdPeriodo, filtro);
                if (periodoEntity.Id == Guid.Empty)
                    return RequestResult<PeriodoPdvDto>.BadRequest("Período não localizado");

                if (periodoEntity.Habilitado)
                    periodoEntity.DesabilitarEntidade();
                else
                    periodoEntity.HabilitarEntidade();

                var periodoUpdateResult = _repository.PeriodoPdvRepository.Update(periodoEntity, filtro);

                if (!await _repository.CommitAsync())
                    return RequestResult<PeriodoPdvDto>.BadRequest();

                var dto = DtoMapper.ParcePeriodoPdvDto(periodoUpdateResult);

                return RequestResult<PeriodoPdvDto>.Ok(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<PeriodoPdvDto>.BadRequest(ex.Message);
            }
        }
    }
}

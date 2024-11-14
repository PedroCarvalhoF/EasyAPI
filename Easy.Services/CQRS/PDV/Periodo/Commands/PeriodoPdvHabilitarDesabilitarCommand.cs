using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Commands
{
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
                    var periodoUpdate = (await _repository.PeriodoPdvRepository.SelectAsync(new Domain.Entities.PDV.Periodo.PeriodoPdvEntityFilter
                    {
                        Id = request.PeriodoPdvDtoRequestId.IdPeriodo
                    }, filtro)).SingleOrDefault();

                    if (periodoUpdate == null)
                        return new RequestResult<PeriodoPdvDto>().Erro("Período não localizado.");

                    if (periodoUpdate.Habilitado)
                        periodoUpdate.DesabilitarEntidade();
                    else
                        periodoUpdate.HabilitarEntidade();

                    await _repository.PeriodoPdvBaseRepository.Update(periodoUpdate);

                    if (!await _repository.CommitAsync())
                        return RequestResult<PeriodoPdvDto>.BadRequest(mensagem: "Não foi possível salvar no banco");

                    PeriodoPdvDto dto = DtoMapper.ParcePeriodoPdvDto(periodoUpdate);

                    return RequestResult<PeriodoPdvDto>.Ok(dto);

                }
                catch (Exception ex)
                {

                    return new RequestResult<PeriodoPdvDto>().Erro(ex);
                }
            }
        }
    }
}

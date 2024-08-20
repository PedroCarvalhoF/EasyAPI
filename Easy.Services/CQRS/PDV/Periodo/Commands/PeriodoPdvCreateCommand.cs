using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Commands;

public class PeriodoPdvCreateCommand : BaseCommands<PeriodoPdvDto>
{
    public required PeriodoPdvDtoCreate PeriodoPdvDtoCreate { get; set; }

    public class PeriodoPdvCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PeriodoPdvCreateCommand, RequestResult<PeriodoPdvDto>>
    {
        public async Task<RequestResult<PeriodoPdvDto>> Handle(PeriodoPdvCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var periodoEnittyCreate = PeriodoPdvEntity.Create(request.PeriodoPdvDtoCreate.DescricaoPeriodo, request.GetFiltro());
                if (!periodoEnittyCreate.Validada)
                    return RequestResult<PeriodoPdvDto>.BadRequest();


                var periodoExists = await _repository.PeriodoPdvRepository.SelectAsync(request.PeriodoPdvDtoCreate.DescricaoPeriodo, filtro);
                if (periodoExists.Id !=Guid.Empty)
                    return RequestResult<PeriodoPdvDto>.BadRequest("Descrição do período já esta em uso.");

                await _repository.PeriodoPdvRepository.InsertAsync(periodoEnittyCreate, filtro);

                if (!await _repository.CommitAsync())
                    return RequestResult<PeriodoPdvDto>.BadRequest();

                PeriodoPdvDto dto = DtoMapper.ParcePeriodoPdvDto(periodoEnittyCreate);

                return RequestResult<PeriodoPdvDto>.Ok(dto);

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

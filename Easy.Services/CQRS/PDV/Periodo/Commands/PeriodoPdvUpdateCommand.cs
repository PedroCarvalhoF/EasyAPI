using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PeriodoPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Commands;

//TEMPORARIO - REALIZAR REQUISIÇÕES ESPECIFICAS DE UPDATE
public class PeriodoPdvUpdateCommand : BaseCommands<PeriodoPdvDto>
{
    public required PeriodoPdvDtoUpdate PeriodoPdvDtoUpdate { get; set; }
    public class PeriodoPdvUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PeriodoPdvUpdateCommand, RequestResult<PeriodoPdvDto>>
    {
        public async Task<RequestResult<PeriodoPdvDto>> Handle(PeriodoPdvUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var periodoEntityUpdate = PeriodoPdvEntity.Update(request.PeriodoPdvDtoUpdate.Id, request.PeriodoPdvDtoUpdate.Habilitado, request.PeriodoPdvDtoUpdate.DescricaoPeriodo, filtro);

                if (!periodoEntityUpdate.Validada)
                    return RequestResult<PeriodoPdvDto>.EntidadeInvalida();


                var PeriodoExists = await _repository.PeriodoPdvRepository.SelectAsync(new PeriodoPdvEntityFilter
                {
                    Id = periodoEntityUpdate.Id
                }, filtro);
                if (!PeriodoExists.Any())
                    return new RequestResult<PeriodoPdvDto>().Erro("Período não localizado.");


                var descricaoPeriodoExists = await _repository.PeriodoPdvRepository.SelectAsync(new PeriodoPdvEntityFilter
                {
                    DescricaoPeriodoEquals = periodoEntityUpdate.DescricaoPeriodo
                }, filtro);


                if (descricaoPeriodoExists.Any())
                    if (descricaoPeriodoExists.Single().Id != periodoEntityUpdate.Id)
                        return new RequestResult<PeriodoPdvDto>().Erro("Descrição do período já esta em uso.");

                await _repository.PeriodoPdvBaseRepository.Update(periodoEntityUpdate);
                if (!await _repository.CommitAsync())
                    return RequestResult<PeriodoPdvDto>.FalhaCommitRepository();

                var dto = DtoMapper.ParcePeriodoPdvDto(periodoEntityUpdate);

                return new RequestResult<PeriodoPdvDto>().ResultOk(dto);

            }
            catch (Exception ex)
            {

                return new RequestResult<PeriodoPdvDto>().Erro(ex);
            }
        }
    }
}

using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PDV;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Commands;

public class PontoVendaAberturaCommand : BaseCommands<PontoVendaDto>
{
    public required PontoVendaDtoCreate PDVCreate { get; set; }

    public class PontoVendaCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PontoVendaAberturaCommand, RequestResult<PontoVendaDto>>
    {
        public async Task<RequestResult<PontoVendaDto>> Handle(PontoVendaAberturaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var pontoVendaEntityCreate =
                    PontoVendaEntity.Create(filtro.userId, request.PDVCreate.UsuarioPdvId, request.PDVCreate.PeriodoPdvId, filtro);

                if (!pontoVendaEntityCreate.Validada)
                    return RequestResult<PontoVendaDto>.BadRequest();

                await _repository.PontoVendaBaseRepository.InsertAsync(pontoVendaEntityCreate);
                if (!await _repository.CommitAsync())
                    return RequestResult<PontoVendaDto>.BadRequest();

                var pdvCreate = await _repository.PontoVendaRepository.GetPdvById(pontoVendaEntityCreate.Id, filtro, true);
                if (pdvCreate.Id == Guid.Empty)
                    return RequestResult<PontoVendaDto>.BadRequest("Não foi possível realizar abertura do ponto de venda.");

                var dto = DtoMapper.ParcePontoVendaDto(pdvCreate);

                return RequestResult<PontoVendaDto>.Ok(dto);

            }

            catch (Exception ex)
            {

                return RequestResult<PontoVendaDto>.BadRequest(ex.Message);
            }
        }
    }
}

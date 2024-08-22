using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PDV;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Queries;

public class GetPontoVendaQuery : BaseCommands<IEnumerable<PontoVendaDto>>
{
    public required PontoVendaQueryFilter PontoVendaQueryFilter { get; set; }
    public class GetPontoVendaQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPontoVendaQuery, RequestResult<IEnumerable<PontoVendaDto>>>
    {
        public async Task<RequestResult<IEnumerable<PontoVendaDto>>> Handle(GetPontoVendaQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var filtro = request.GetFiltro();
                var pdvsEntities = await _repository.PontoVendaRepository.SelectAsync(request.PontoVendaQueryFilter, filtro, true);
                var dtos = DtoMapper.ParcePontosVendasDtos(pdvsEntities);

                return RequestResult<IEnumerable<PontoVendaDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                return RequestResult<IEnumerable<PontoVendaDto>>.BadRequest(ex.Message);
            }
        }
    }
}

using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Queries;

public class GetPontoVendaQueryPdvFilter : BaseCommandsForUpdate
{
    public required PontoVendaQueryFilter PontoVendaQueryFilter { get; set; }

    public class GetPontoVendaQueryPdvFilterHandler(IUnitOfWork _repository) : IRequestHandler<GetPontoVendaQueryPdvFilter, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetPontoVendaQueryPdvFilter request, CancellationToken cancellationToken)
        {
            try
            {
                var pdvsEntities = await _repository.PontoVendaRepository.SelectAsync(request.PontoVendaQueryFilter, request.GetFiltro());
                return new RequestResultForUpdate().Ok(pdvsEntities);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

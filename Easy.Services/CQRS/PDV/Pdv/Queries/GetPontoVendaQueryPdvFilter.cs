using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Queries;

public class GetPontoVendaQueryPdvFilter : BaseCommands
{
    public PontoVendaQueryFilter PontoVendaQueryFilter { get; set; }

    public class GetPontoVendaQueryPdvFilterHandler(IUnitOfWork _repository) : IRequestHandler<GetPontoVendaQueryPdvFilter, RequestResult>
    {
        public async Task<RequestResult> Handle(GetPontoVendaQueryPdvFilter request, CancellationToken cancellationToken)
        {
            try
            {
                var pdvsEntities = await _repository.PontoVendaRepository.SelectAsync(request.PontoVendaQueryFilter, request.GetFiltro());
                return new RequestResult().Ok(pdvsEntities);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

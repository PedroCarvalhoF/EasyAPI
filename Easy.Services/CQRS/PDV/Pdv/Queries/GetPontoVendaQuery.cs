using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Queries;

public class GetPontoVendaQuery : BaseCommandsForUpdate
{
    public class GetPontoVendaQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPontoVendaQuery, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetPontoVendaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pdvsEntities = await _repository.PontoVendaBaseRepository.SelectAsync(request.GetFiltro());
                return new RequestResultForUpdate().Ok(pdvsEntities);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

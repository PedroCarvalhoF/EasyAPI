using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Queries;

public class GetPontoVendaQuery : BaseCommands
{
    public class GetPontoVendaQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPontoVendaQuery, RequestResult>
    {
        public async Task<RequestResult> Handle(GetPontoVendaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var pdvsEntities = await _repository.PontoVendaBaseRepository.SelectAsync(request.GetFiltro());
                return new RequestResult().Ok(pdvsEntities);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

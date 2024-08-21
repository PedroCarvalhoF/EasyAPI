using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Commands
{
    public class PontoVendaCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PontoVendaAberturaCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(PontoVendaAberturaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pontoVendaEntityCreate =
                    PontoVendaEntity.Create(request.UsuarioGerentePdvId, request.UsuarioPdvId, request.PeriodoPdvId, request.GetFiltro());

                if (!pontoVendaEntityCreate.Validada)
                    return new RequestResultForUpdate().EntidadeInvalida();

                await _repository.PontoVendaBaseRepository.InsertAsync(pontoVendaEntityCreate);
                if (await _repository.CommitAsync())
                    return new RequestResultForUpdate().Ok();

                return new RequestResultForUpdate().BadRequest();

            }

            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

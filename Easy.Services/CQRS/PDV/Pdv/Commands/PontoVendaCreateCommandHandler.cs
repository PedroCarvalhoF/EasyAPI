using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Commands
{
    public class PontoVendaCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PontoVendaCreateCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(PontoVendaCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pontoVendaEntityCreate =
                    PontoVendaEntity.Create(request.UsuarioGerentePdvId, request.UsuarioPdvId, request.PeriodoPdvId, request.GetFiltro());

                if (!pontoVendaEntityCreate.Validada)
                    return new RequestResult().EntidadeInvalida();

                await _repository.PontoVendaBaseRepository.InsertAsync(pontoVendaEntityCreate);
                if (await _repository.CommitAsync())
                    return new RequestResult().Ok();

                return new RequestResult().BadRequest();

            }

            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

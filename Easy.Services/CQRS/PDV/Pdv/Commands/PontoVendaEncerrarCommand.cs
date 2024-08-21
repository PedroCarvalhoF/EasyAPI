using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Commands;

public class PontoVendaEncerrarCommand : BaseCommandsForUpdate
{
    public Guid IdPdv { get; set; }

    public class PontoVendaEncerrarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PontoVendaEncerrarCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(PontoVendaEncerrarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pdvSelecionado = await _repository.PontoVendaBaseRepository.SelectAsync(request.IdPdv, request.GetFiltro());

                pdvSelecionado.EncerrarPontoVenda();

                if (!pdvSelecionado.Validada)
                    return new RequestResultForUpdate().EntidadeInvalida();

                 _repository.PontoVendaBaseRepository.Update(pdvSelecionado);
                if (await _repository.CommitAsync())
                    return new RequestResultForUpdate().Ok();

                return new RequestResultForUpdate().BadRequest("Não foi possível encerrar ponto de venda.");
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

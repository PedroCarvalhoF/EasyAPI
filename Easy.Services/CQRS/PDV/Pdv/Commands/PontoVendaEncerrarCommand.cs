using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Commands;

public class PontoVendaEncerrarCommand : BaseCommands
{
    public Guid IdPdv { get; set; }

    public class PontoVendaEncerrarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PontoVendaEncerrarCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(PontoVendaEncerrarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pdvSelecionado = await _repository.PontoVendaBaseRepository.SelectAsync(request.IdPdv, request.GetFiltro());

                pdvSelecionado.EncerrarPontoVenda();

                if (!pdvSelecionado.Validada)
                    return new RequestResult().EntidadeInvalida();

                await _repository.PontoVendaBaseRepository.UpdateAsync(pdvSelecionado, request.GetFiltro());
                if (await _repository.CommitAsync())
                    return new RequestResult().Ok();

                return new RequestResult().BadRequest("Não foi possível encerrar ponto de venda.");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

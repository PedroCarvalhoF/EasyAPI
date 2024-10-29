using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PDV;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Commands;

public class PontoVendaEncerrarCommand : BaseCommands<PontoVendaDtoEncerrarResult>
{
    public Guid IdPdv { get; set; }

    public class PontoVendaEncerrarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PontoVendaEncerrarCommand, RequestResult<PontoVendaDtoEncerrarResult>>
    {
        public async Task<RequestResult<PontoVendaDtoEncerrarResult>> Handle(PontoVendaEncerrarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pdvs_filtrado = await _repository.PontoVendaRepository.SelectAsync(new Domain.Entities.PDV.PDV.PontoVendaQueryFilter
                {
                    IdPdv = request.IdPdv
                }, request.GetFiltro());

                var pdvSelecionado = pdvs_filtrado.SingleOrDefault();

                if (pdvSelecionado == null)
                    return RequestResult<PontoVendaDtoEncerrarResult>.BadRequest();

                pdvSelecionado.EncerrarPontoVenda();

                if (!pdvSelecionado.Validada)
                    return RequestResult<PontoVendaDtoEncerrarResult>.BadRequest();

                await _repository.PontoVendaBaseRepository.Update(pdvSelecionado);
                if (await _repository.CommitAsync())
                {
                    PontoVendaDtoEncerrarResult result = PontoVendaDtoEncerrarResult.PontoVendaEncerrado(true);

                    return RequestResult<PontoVendaDtoEncerrarResult>.Ok(result);
                }
                return RequestResult<PontoVendaDtoEncerrarResult>.BadRequest(PontoVendaDtoEncerrarResult.PontoVendaEncerrado(false));
            }
            catch (Exception ex)
            {

                return RequestResult<PontoVendaDtoEncerrarResult>.BadRequest(ex.Message);
            }
        }
    }
}

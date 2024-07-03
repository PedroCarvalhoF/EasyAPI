using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Commands;

public class PeriodoPdvCreateCommand : BaseCommands
{
    public string DescricaoPeriodo { get; private set; }
    public PeriodoPdvCreateCommand(string descricaoPeriodo)
    {
        DescricaoPeriodo = descricaoPeriodo;
    }

    public class PeriodoPdvCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PeriodoPdvCreateCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(PeriodoPdvCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var periodoEnittyCreate = PeriodoPdvEntity.Create(request.DescricaoPeriodo, request.GetFiltro());
                if (!periodoEnittyCreate.Validada)
                    return new RequestResult().EntidadeInvalida();

                var periodoExists = await _repository.PeriodoPdvRepository.SelectAsync(request.DescricaoPeriodo, filtro);
                if (periodoExists != null)
                    return new RequestResult().BadRequest("Descrição do período está em uso.");

                await _repository.PeriodoPdvRepository.InsertAsync(periodoEnittyCreate, filtro);

                if (!await _repository.CommitAsync())
                    return new RequestResult().BadRequest();

                return new RequestResult().Ok("Período criado com sucesso");

            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

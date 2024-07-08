using Easy.Domain.Entities.PDV.Periodo;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Periodo.Commands;

public class PeriodoPdvUpdateCommand : BaseCommandsForUpdate
{
    public PeriodoPdvUpdateCommand(Guid id, bool habilitado, string descricaoPeriodo)
    {
        Id = id;
        Habilitado = habilitado;
        DescricaoPeriodo = descricaoPeriodo;
    }
    public Guid Id { get; private set; }
    public bool Habilitado { get; private set; }
    public string DescricaoPeriodo { get; private set; }

    public class PeriodoPdvUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PeriodoPdvUpdateCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(PeriodoPdvUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var periodoPdvUpdateEntity = PeriodoPdvEntity.Update(request.Id, request.Habilitado, request.DescricaoPeriodo, filtro);
                if (!periodoPdvUpdateEntity.Validada)
                    return new RequestResultForUpdate().EntidadeInvalida();



                var periodoExists = await _repository.PeriodoPdvRepository.SelectAsync(periodoPdvUpdateEntity.DescricaoPeriodo, filtro);
                if (periodoExists != null)
                    return new RequestResultForUpdate().BadRequest("Descrição do período está em uso.");

                await _repository.PeriodoPdvRepository.Update(periodoPdvUpdateEntity, filtro);
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


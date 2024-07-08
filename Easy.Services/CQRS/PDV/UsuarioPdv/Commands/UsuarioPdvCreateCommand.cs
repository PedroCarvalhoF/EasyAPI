using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvCreateCommand : BaseCommandsForUpdate
{
    public Guid UserPdvId { get; set; }

    public class UsuarioPdvCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<UsuarioPdvCreateCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(UsuarioPdvCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarioPdv = UsuarioPdvEntity.Create(request.UserPdvId, request.GetFiltro());
                if (!usuarioPdv.Validada)
                    return new RequestResultForUpdate().EntidadeInvalida();

                await _repository.UsuarioPdvRepository.InsertAsync(usuarioPdv, request.GetFiltro());
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

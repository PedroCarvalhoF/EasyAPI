using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UsuarioPdv;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvCreateCommand : BaseCommandsForUpdate
{
    public required UsuarioPdvDtoCreate UsuarioPdv { get; set; }

    public class UsuarioPdvCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<UsuarioPdvCreateCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(UsuarioPdvCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var usuarioPdv = UsuarioPdvEntity.Create(request.UsuarioPdv.UserPdvId, filtro);
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

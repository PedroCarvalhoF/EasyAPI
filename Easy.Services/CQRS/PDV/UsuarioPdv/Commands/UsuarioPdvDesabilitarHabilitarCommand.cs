using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvDesabilitarHabilitarCommand : BaseCommandsForUpdate
{
    public Guid UserPdvId { get; set; }
    public bool Habiitado { get; set; }

    public class UsuarioPdvDesabilitarCommandHandler(IUnitOfWork _repository) : IRequestHandler<UsuarioPdvDesabilitarHabilitarCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(UsuarioPdvDesabilitarHabilitarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarioHabilitar = await _repository.UsuarioPdvRepository.SelectByIdUsuarioPdvAsync(request.UserPdvId, request.GetFiltro());
                if (usuarioHabilitar == null)
                    return new RequestResultForUpdate().BadRequest("Usuário não localizado");

                if (request.Habiitado)
                {
                    usuarioHabilitar.Habilitar();
                }
                else
                {
                    usuarioHabilitar.Desabilitar();
                }

                if (!usuarioHabilitar.Validada)
                    return new RequestResultForUpdate().EntidadeInvalida();

                var usuarioDesabilitarUpdateResult = await _repository.UsuarioPdvRepository.UpdateAsync(usuarioHabilitar, request.GetFiltro());

                if (await _repository.CommitAsync())
                    return new RequestResultForUpdate().Ok("Usuário desabilitado com sucesso");

                return new RequestResultForUpdate().BadRequest();

            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

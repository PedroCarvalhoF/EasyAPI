using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvCreateCommand : BaseCommands
{
    public Guid UserPdvId { get; set; }

    public class UsuarioPdvCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<UsuarioPdvCreateCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(UsuarioPdvCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarioPdv = UsuarioPdvEntity.Create(request.UserPdvId, request.GetFiltro());
                if (!usuarioPdv.Validada)
                    return new RequestResult().EntidadeInvalida();

                await _repository.UsuarioPdvRepository.InsertAsync(usuarioPdv, request.GetFiltro());
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

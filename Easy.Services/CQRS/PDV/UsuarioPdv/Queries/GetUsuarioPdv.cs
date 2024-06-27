using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Enuns.Pdv.UserPDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Queries;

public class GetUsuarioPdv : BaseCommands
{
    public UsuarioPdvFiltroEnum UsuarioPdvFiltroEnum { get; set; }
    public class GetUsuarioPdvHandler(IUnitOfWork _repository) : IRequestHandler<GetUsuarioPdv, RequestResult>
    {
        public async Task<RequestResult> Handle(GetUsuarioPdv request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<UsuarioPdvEntity> result;
                var filtro = request.GetFiltro();

                if (request.UsuarioPdvFiltroEnum == UsuarioPdvFiltroEnum.TodosUsuarios)
                    result = await _repository.UsuarioPdvRepository.SelectAsync(request.GetFiltro());
                else
                    result = await _repository.UsuarioPdvRepository.SelectAsync(request.UsuarioPdvFiltroEnum, filtro);

                return new RequestResult().Ok(result);
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}


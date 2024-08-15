using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Enuns.Pdv.UserPDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Queries;

public class UsuarioPdvQueryGet : BaseCommands<IEnumerable<UserDto>>
{
    public UsuarioPdvFiltroEnum UsuarioPdvFiltroEnum { get; set; }
    public class GetUsuarioPdvHandler(IUnitOfWork _repository) : IRequestHandler<UsuarioPdvQueryGet, RequestResult<IEnumerable<UserDto>>>
    {
        public async Task<RequestResult<IEnumerable<UserDto>>> Handle(UsuarioPdvQueryGet request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<UsuarioPdvEntity> usuariosPdvsEntities;

                var filtro = request.GetFiltro();

                if (request.UsuarioPdvFiltroEnum == UsuarioPdvFiltroEnum.TodosUsuarios)
                    usuariosPdvsEntities = await _repository.UsuarioPdvRepository.SelectAsync(request.GetFiltro());
                else
                    usuariosPdvsEntities = await _repository.UsuarioPdvRepository.SelectAsync(request.UsuarioPdvFiltroEnum, filtro);

                var usersDtos = DtoMapper.ParceUsersDtos(usuariosPdvsEntities);

                return RequestResult<IEnumerable<UserDto>>.Ok(usersDtos);
            }
            catch (Exception ex)
            {
                return RequestResult<IEnumerable<UserDto>>.BadRequest(ex.Message);
            }
        }
    }
}


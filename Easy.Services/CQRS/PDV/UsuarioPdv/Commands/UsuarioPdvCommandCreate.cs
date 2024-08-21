using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UsuarioPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvCommandCreate : BaseCommands<UsuarioPdvDto>
{
    public required UsuarioPdvDtoCreate UsuarioPdv { get; set; }

    public class UsuarioPdvCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<UsuarioPdvCommandCreate, RequestResult<UsuarioPdvDto>>
    {
        public async Task<RequestResult<UsuarioPdvDto>> Handle(UsuarioPdvCommandCreate request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var userPdvCreateEntity = UsuarioPdvEntity.Create(request.UsuarioPdv.UserPdvId, filtro);
                if (!userPdvCreateEntity.Validada)
                    return RequestResult<UsuarioPdvDto>.BadRequest();

                var userPdvExists = await _repository.UsuarioPdvRepository.SelectByIdUsuarioPdvAsync(userPdvCreateEntity.UserPdvId, filtro);
                if (userPdvExists.Id != Guid.Empty)
                    return RequestResult<UsuarioPdvDto>.BadRequest("Usuário já esta na lista para acessar pdv.");

                var userCreateResult = await _repository.UsuarioPdvRepository.InsertAsync(userPdvCreateEntity);

                if (!await _repository.CommitAsync())
                    return RequestResult<UsuarioPdvDto>.BadRequest();

                var userCreate = await _repository.UsuarioPdvRepository.SelectByIdUsuarioPdvAsync(userCreateResult.UserId, filtro);

                var dto = DtoMapper.ParceUsuarioPdvDto(userCreate);

                return RequestResult<UsuarioPdvDto>.Ok(dto);

            }
            catch (Exception ex)
            {

                return RequestResult<UsuarioPdvDto>.BadRequest(ex.Message);
            }
            finally
            {
                _repository.FinalizarContexto();
            }
        }
    }
}

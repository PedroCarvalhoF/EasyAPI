using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UsuarioPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Commands;

public class UsuarioPdvCreateCommand : BaseCommands<UserDto>
{
    public required UsuarioPdvDtoCreate UsuarioPdv { get; set; }

    public class UsuarioPdvCreateCommandHandler(IUnitOfWork _repository, UserManager<UserEntity> _userManager) : IRequestHandler<UsuarioPdvCreateCommand, RequestResult<UserDto>>
    {
        public async Task<RequestResult<UserDto>> Handle(UsuarioPdvCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var usuarioPdv = UsuarioPdvEntity.Create(request.UsuarioPdv.UserPdvId, filtro);
                if (!usuarioPdv.Validada)
                    return RequestResult<UserDto>.BadRequest();

                await _repository.UsuarioPdvRepository.InsertAsync(usuarioPdv, request.GetFiltro());
                if (!await _repository.CommitAsync())
                    return RequestResult<UserDto>.BadRequest();

                var userEntity = await _userManager.FindByIdAsync(usuarioPdv.UserId.ToString());

                var userDto = DtoMapper.ParceUserDto(userEntity!);

                return RequestResult<UserDto>.Ok(userDto, $"{userDto.Nome} tem permissão para acessar ponto de venda.");


            }
            catch (Exception ex)
            {

                return RequestResult<UserDto>.BadRequest(ex.Message);
            }
        }
    }
}

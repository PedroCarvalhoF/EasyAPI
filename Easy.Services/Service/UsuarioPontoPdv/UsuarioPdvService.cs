using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.PDV.UsuarioPdv.Commands;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.Tools.UseCase.Dto;
using Microsoft.AspNetCore.Identity;

namespace Easy.Services.Service.UsuarioPontoPdv;

public class UsuarioPdvService(IUnitOfWork _repository, UserManager<UserEntity> _userManager) : IUsuarioPdvService
{
    public async Task<RequestResult<UserDto>> HabilitarDesabilitarCommand(UsuarioPdvCommandHabilitarDesabilitar command)
    {

        try
        {
            var usuarioHabilitar = await _repository.UsuarioPdvRepository.SelectByIdUsuarioPdvAsync(command.UsuarioPdvDto.UserPdvId, command.GetFiltro());
            if (usuarioHabilitar == null)
                return RequestResult<UserDto>.BadRequest("Usuário não localizado");

            if (command.UsuarioPdvDto.Habiitado)
            {
                usuarioHabilitar.Habilitar();
            }
            else
            {
                usuarioHabilitar.Desabilitar();
            }

            if (!usuarioHabilitar.Validada)
                return RequestResult<UserDto>.BadRequest("Usuário não localizado");

            var usuarioDesabilitarUpdateResult = _repository.UsuarioPdvRepository.UpdateAsync(usuarioHabilitar, command.GetFiltro());

            if (await _repository.CommitAsync())
                if (usuarioDesabilitarUpdateResult.Habilitado)
                    return RequestResult<UserDto>.Ok(mensagem: "Usuário Habilitado");
                else
                    return RequestResult<UserDto>.Ok(mensagem: "Usuário Desabilitado");

            return RequestResult<UserDto>.BadRequest();
        }
        catch (Exception ex)
        {

            return RequestResult<UserDto>.BadRequest(ex.Message);
        }
    }

    public async Task<RequestResult<UserDto>> UsuarioPdvCreateCommand(UsuarioPdvCommandCreate request)
    {
        try
        {
            var filtro = request.GetFiltro();

            var usuarioPdv = UsuarioPdvEntity.Create(request.UsuarioPdv.UserPdvId, filtro);
            if (!usuarioPdv.Validada)
                return RequestResult<UserDto>.BadRequest();

            await _repository.UsuarioPdvRepository.InsertAsync(usuarioPdv);
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

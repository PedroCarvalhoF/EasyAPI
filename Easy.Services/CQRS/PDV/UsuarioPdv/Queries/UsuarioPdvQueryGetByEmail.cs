using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UsuarioPdv;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Easy.Services.CQRS.PDV.UsuarioPdv.Queries
{
    public class UsuarioPdvQueryGetByEmail : BaseCommands<UsuarioPdvDto>
    {
        [Required]
        public UserDtoRequestEmail UserDtoRequestEmail { get; private set; }

        public UsuarioPdvQueryGetByEmail(UserDtoRequestEmail userDtoRequestEmail)
        {
            UserDtoRequestEmail = userDtoRequestEmail;
        }

        public class UsuarioPdvQueryGetByIdHandler(IUnitOfWork _repository, UserManager<UserEntity> _userManager) : IRequestHandler<UsuarioPdvQueryGetByEmail, RequestResult<UsuarioPdvDto>>
        {
            public async Task<RequestResult<UsuarioPdvDto>> Handle(UsuarioPdvQueryGetByEmail request, CancellationToken cancellationToken)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(request.UserDtoRequestEmail.Email);
                    if (user == null)
                        return RequestResult<UsuarioPdvDto>.BadRequest("Usuário não localizado.");

                    var usuarioEntity = await _repository.UsuarioPdvRepository.SelectByIdUsuarioPdvAsync(user.Id, request.GetFiltro());
                    if (usuarioEntity == null)
                        return RequestResult<UsuarioPdvDto>.BadRequest("Usuário não está na lista para acesso ao caixa(pdv).");

                    var dto = DtoMapper.ParceUsuarioPdvDto(usuarioEntity);

                    return new RequestResult<UsuarioPdvDto>().ResultOk(dto);
                }
                catch (Exception ex)
                {

                    return RequestResult<UsuarioPdvDto>.BadRequest(ex.Message);
                }
            }
        }
    }
}

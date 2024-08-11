using AutoMapper;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Easy.Services.CQRS.UserMasterUser.Queries;

public class GetUserMasterUserByIdUser : BaseCommands<UserDto>
{
    [Required]
    public Guid IdUser { get; private set; }
    public GetUserMasterUserByIdUser(Guid idUser)
    {
        IdUser = idUser;
    }

    public int MyProperty { get; set; }

    public class GetUserMasterUserByIdUserHandler(IUnitOfWork _repository, IMapper _mapper) : IRequestHandler<GetUserMasterUserByIdUser, RequestResult<UserDto>>
    {
        public async Task<RequestResult<UserDto>> Handle(GetUserMasterUserByIdUser request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.UserMasterUserRepository.GetById(request.IdUser);

                if (user is null)
                    return RequestResult<UserDto>.BadRequest("Usuário não localizado.");

                var dto = DtoMapper.ParceUserMasterUserDto(user);
                return RequestResult<UserDto>.Ok(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<UserDto>.BadRequest(ex.Message);
            }
        }
    }
}

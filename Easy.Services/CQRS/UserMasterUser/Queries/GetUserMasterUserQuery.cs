using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Queries;

public class GetUserMasterUserQuery : BaseCommands<IEnumerable<UserDto>>
{
    public class GetUserMasterUserQueryHandler(IUserMasterUserDapperRepository<FiltroBase> _repository) : IRequestHandler<GetUserMasterUserQuery, RequestResult<IEnumerable<UserDto>>>
    {
        public async Task<RequestResult<IEnumerable<UserDto>>> Handle(GetUserMasterUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetUsersMasterUsersAsync(request.GetFiltro());
                var dtos = DtoMapper.ParceUsersDtos(result);
                return RequestResult<IEnumerable<UserDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

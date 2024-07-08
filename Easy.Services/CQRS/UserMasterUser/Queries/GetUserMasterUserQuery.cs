using AutoMapper;
using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.Services.CQRS.PDV;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Queries;

public class GetUserMasterUserQuery : BaseCommandsForUpdate
{
    public class GetUserMasterUserQueryHandler : IRequestHandler<GetUserMasterUserQuery, RequestResultForUpdate>
    {
        private readonly IUserMasterUserDapperRepository<FiltroBase> _repository;
        private readonly IMapper _mapper;

        public GetUserMasterUserQueryHandler(IUserMasterUserDapperRepository<FiltroBase> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResultForUpdate> Handle(GetUserMasterUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetUsersMasterUsersAsync(request.GetFiltro());
                return new RequestResultForUpdate().Ok(_mapper.Map<ICollection<UserDto>>(result));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

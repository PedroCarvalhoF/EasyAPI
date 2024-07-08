using AutoMapper;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Services.CQRS.PDV;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;

namespace Easy.Services.CQRS.User.Queries;

public class GetUsersQuery : BaseCommandsForUpdate
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, RequestResultForUpdate>
    {
        private readonly IUserDappperRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserDappperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResultForUpdate> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _repository.GetUsersAscyn();
                var dtos = _mapper.Map<ICollection<UserDto>>(entities);
                return new RequestResultForUpdate().Ok(dtos);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

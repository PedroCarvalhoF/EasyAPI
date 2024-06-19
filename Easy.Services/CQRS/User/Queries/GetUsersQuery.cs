using AutoMapper;
using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;

namespace Easy.Services.CQRS.User.Queries;

public class GetUsersQuery : IRequest<RequestResult>
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, RequestResult>
    {
        private readonly IUserDapperRepository _UserDapperRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserDapperRepository userDapperRepository, IMapper mapper)
        {
            _UserDapperRepository = userDapperRepository;
           _mapper = mapper;
        }

        public async Task<RequestResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _UserDapperRepository.GetUsers();
            var usersDtos = _mapper.Map<IEnumerable<UserView>>(users);

            return new RequestResult().Ok(usersDtos);
        }
    }
}

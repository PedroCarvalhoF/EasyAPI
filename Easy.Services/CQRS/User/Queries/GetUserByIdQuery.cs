using AutoMapper;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;

namespace Easy.Services.CQRS.User.Queries;

public class GetUserByIdQuery : IRequest<RequestResult>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, RequestResult>
    {
        private readonly IUserDapperRepository _userDapperRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserDapperRepository userDapperRepository, IMapper mapper)
        {
            _userDapperRepository = userDapperRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userDapperRepository.GetUserByIdAsync(request.Id);

            return new RequestResult().Ok(_mapper.Map<UserView>(user));
        }
    }
}

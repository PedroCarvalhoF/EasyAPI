using Easy.Domain.Entities.User;
using Easy.Domain.Intefaces.Repository.User;
using MediatR;

namespace Easy.Services.CQRS.User.Queries;

public class GetUserByIdQuery : IRequest<UserEntity>
{
    public Guid Id { get; set; }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        private readonly IUserDapperRepository _userDapperRepository;

        public GetUserByIdQueryHandler(IUserDapperRepository userDapperRepository)
        {
            _userDapperRepository = userDapperRepository;
        }

        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user= await _userDapperRepository.GetUserById(request.Id);
            return user;    
        }
    }
}

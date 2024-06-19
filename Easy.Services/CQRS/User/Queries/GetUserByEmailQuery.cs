using AutoMapper;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;

namespace Easy.Services.CQRS.User.Queries;

public class GetUserByEmailQuery : IRequest<RequestResult>
{
    public string Email { get; private set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }

    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, RequestResult>
    {
        private readonly IUserDapperRepository _userDapperRepository;
        private readonly IMapper _mapper;

        public GetUserByEmailHandler(IUserDapperRepository userDapperRepository, IMapper mapper)
        {
            _userDapperRepository = userDapperRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _userDapperRepository.GetUserByEmailAsync(request.Email);
                if (entity == null) return new RequestResult().IsNullOrCountZero();
                return new RequestResult().Ok(_mapper.Map<UserView>(entity));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadCreate(ex.Message);
            }
        }
    }
}

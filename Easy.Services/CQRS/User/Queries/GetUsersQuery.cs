using AutoMapper;
using Easy.Domain.Intefaces.Repository.User;
using Easy.Services.CQRS.PDV;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;

namespace Easy.Services.CQRS.User.Queries;

public class GetUsersQuery : BaseCommands
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, RequestResult>
    {
        private readonly IUserDappperRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserDappperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _repository.GetUsersAscyn();
                var dtos = _mapper.Map<ICollection<UserDto>>(entities);
                return new RequestResult().Ok(dtos);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

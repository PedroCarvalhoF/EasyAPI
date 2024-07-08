using AutoMapper;
using Easy.Domain.Intefaces.Repository.UserMasterCliente;
using Easy.Services.CQRS.PDV;
using Easy.Services.DTOs;
using Easy.Services.DTOs.User;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Queries;

public class GetUserMasterClienteQuery : BaseCommandsForUpdate
{
    public class GetUserMasterClienteQueryHandler : IRequestHandler<GetUserMasterClienteQuery, RequestResultForUpdate>
    {
        private readonly IUserMasterClienteDapperRepository _repository;
        private readonly IMapper _mapper;

        public GetUserMasterClienteQueryHandler(IUserMasterClienteDapperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResultForUpdate> Handle(GetUserMasterClienteQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _repository.GetUsersClientesAsync();
                return new RequestResultForUpdate().Ok(_mapper.Map<IEnumerable<UserDto>>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

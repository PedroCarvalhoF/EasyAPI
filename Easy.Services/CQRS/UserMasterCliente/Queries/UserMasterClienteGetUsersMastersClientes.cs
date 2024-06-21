using AutoMapper;
using Easy.Domain.Intefaces.Repository.UsuarioMasterCliente;
using Easy.Services.DTOs;
using Easy.Services.DTOs.UserMaster;
using MediatR;

namespace Easy.Services.CQRS.UserMasterCliente.Queries
{
    public class UserMasterClienteGetUsersMastersClientes : IRequest<RequestResult>
    {
        public class UserMasterClienteGetUserMasterClientesHandler : IRequestHandler<UserMasterClienteGetUsersMastersClientes, RequestResult>
        {
            private readonly IUserMasterClienteDapperRepository _repository;
            public readonly IMapper _mapper;

            public UserMasterClienteGetUserMasterClientesHandler(IUserMasterClienteDapperRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<RequestResult> Handle(UserMasterClienteGetUsersMastersClientes request, CancellationToken cancellationToken)
            {
                try
                {
                    var entities = await _repository.GetUsersMastersClientesAsync();
                    return new RequestResult().Ok(_mapper.Map<IEnumerable<UserMasterClienteView>>(entities));
                }
                catch (Exception ex)
                {

                    return new RequestResult().BadRequest(ex.Message);
                }
            }
        }
    }
}

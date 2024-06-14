using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.UsersDtos;
using Domain.Interfaces;
using Domain.Interfaces.Repository.UserMasterCliente;
using Domain.Interfaces.Services.UserMasterCliente;
using Domain.UserIdentity.Masters;
using Domain.UserIdentity.MasterUsers;

namespace Service.Services.UserMaster
{
    public class UserMasterClienteServices : IUserMasterClienteServices
    {
        private readonly IRepositoryGeneric<UserMasterClienteEntity>? _userMasterClienteRepository;
        private readonly IUserMasterClienteRepository? _UserMasterClienteRepository;
        private readonly IMapper? _mapper;

        private readonly IRepositoryGeneric<UserMasterUserEntity>? _userMasterUsersRepository;
        public UserMasterClienteServices(IRepositoryGeneric<UserMasterClienteEntity>? repositoryGeneric, IRepositoryGeneric<UserMasterUserEntity>? userMasterUsersRepository, IUserMasterClienteRepository? userMasterClienteRepository, IMapper? mapper)
        {
            _userMasterClienteRepository = repositoryGeneric;
            _userMasterUsersRepository = userMasterUsersRepository;
            _UserMasterClienteRepository = userMasterClienteRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> CadastrarUserMasterCliente(Guid userId)
        {
            try
            {
                UserMasterClienteEntity userMaster = new UserMasterClienteEntity
                {
                    UserMasterId = userId,
                };

                var result = await _userMasterClienteRepository.InsertGenericAsync(userMaster);

                var resultExists = await _userMasterClienteRepository.SelectGenericAsync(result.UserMasterId);
                if (resultExists.UserMasterId == userId)
                    return new RequestResult().Ok("Usuário agora é MasterCliente");
                return new RequestResult().BadRequest("Não foi possível cadastrar usuario master");
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }

        public async Task<RequestResult> GerarCredencialUsuario(Guid userIdCliente, Guid userForCredential)
        {
            try
            {
                var userMasterUser = new UserMasterUserEntity
                {
                    UserMasterClienteIdentityId = userIdCliente,
                    UserId = userForCredential
                };

                var resultUsermasterUser = await _userMasterUsersRepository.InsertGenericAsync(userMasterUser);

                if (resultUsermasterUser != null)
                    return new RequestResult().Ok("Usuário agora tem sua crendencial");

                return new RequestResult().BadRequest("Não foi possível crendeciar");
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }

        public async Task<RequestResult> GetUserMastersCliente()
        {
            try
            {
                var userMasterClientes = await _UserMasterClienteRepository.GetUserMastersCliente();
                if (userMasterClientes == null || userMasterClientes.Count() == 0)
                    return new RequestResult().IsNullOrCountZero();


                var dtos = _mapper.Map<IEnumerable<UserMasterClienteDto>>(userMasterClientes);

                return new RequestResult().Ok(dtos);
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

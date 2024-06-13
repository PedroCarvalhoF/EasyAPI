using Domain.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Services.UserMasterCliente;
using Domain.UserIdentity;
using Domain.UserIdentity.Masters;
using Domain.UserIdentity.MasterUsers;

namespace Service.Services.UserMaster
{
    public class UserMasterClienteServices : IUserMasterClienteServices
    {
        private readonly IRepositoryGeneric<UserMasterClienteEntity>? _userMasterClienteRepository;
        private readonly IRepositoryGeneric<UserMasterUserEntity>? _userMasterUsersRepository;
        public UserMasterClienteServices(IRepositoryGeneric<UserMasterClienteEntity>? repositoryGeneric, IRepositoryGeneric<UserMasterUserEntity>? userMasterUsersRepository)
        {
            _userMasterClienteRepository = repositoryGeneric;
            _userMasterUsersRepository = userMasterUsersRepository;
        }

        public async Task<ResponseDto<List<UsuarioCadastroResponse>>> CadastrarUserMasterCliente(Guid userId)
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
                    return new ResponseDto<List<UsuarioCadastroResponse>>().CadastroOk("Usuário agora é MasterCliente");
                return new ResponseDto<List<UsuarioCadastroResponse>>().Erro("Não foi possível cadastrar usuario master");
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<UsuarioCadastroResponse>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<UsuarioCadastroResponse>>> GerarCredencialUsuario(Guid userIdCliente, Guid userForCredential)
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
                    return new ResponseDto<List<UsuarioCadastroResponse>>().CadastroOk("Usuário agora tem sua crendencial");

                return new ResponseDto<List<UsuarioCadastroResponse>>().Erro("Não foi possível crendeciar");
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<UsuarioCadastroResponse>>().Erro(ex);
            }
        }
    }
}

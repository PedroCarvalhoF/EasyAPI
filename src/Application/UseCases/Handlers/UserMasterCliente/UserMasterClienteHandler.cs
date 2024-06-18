using Application.DTOs.UserMaster;
using Application.Interfaces.Repository;
using Application.Results;
using Application.UseCases.Commands.UserMasterCliente;
using Application.UseCases.Tools;
using AutoMapper;
using Domain.Entities.User;
using Domain.Entities.UserMasterCliente;

namespace Application.UseCases.Handlers.UserMasterCliente
{
    public class UserMasterClienteHandler : IUserMasterClienteHandler<UserMasterCreateCommand>
    {
        private readonly IUsuarioMasterClienteRepository<UserMasterClienteEntity> _repositoryGeneric;
        private readonly IRepositoryGeneric<UserEntity> _userRepository;
        private readonly IMapper _mapper;
        public UserMasterClienteHandler(IUsuarioMasterClienteRepository<UserMasterClienteEntity> repositoryGeneric, IRepositoryGeneric<UserEntity> userRepository, IMapper mapper)
        {
            _repositoryGeneric = repositoryGeneric;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> CadastrarUsuarioMaster(UserMasterCreateCommand command)
        {
            try
            {
                var entity = EntityMapper.UserMasterCliente(command);
                if (!entity.IsValid)
                    return new RequestResult().EntidadeInvalida();

                var userExists = await _userRepository.SelectGenericAsync(entity.UserMasterId);
                if (userExists == null)
                    return new RequestResult().BadRequest("Usuário não localizado");

                var result = await _repositoryGeneric.InsertAsync(entity);
                if (result == null)
                    return new RequestResult().BadRequest("Não foi possível cadastrar usuário master");

                return new RequestResult().Ok("Usuário MASTER criado com sucesso");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }

        public async Task<RequestResult> GetAll()
        {
            try
            {
                var entities = await _repositoryGeneric.GetAllAsync();

                return new RequestResult().Ok(_mapper.Map<IEnumerable<UserMasterClienteView>>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

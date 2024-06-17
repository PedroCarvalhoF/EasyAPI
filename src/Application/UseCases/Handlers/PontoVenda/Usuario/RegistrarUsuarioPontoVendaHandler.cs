using Application.UseCases.Commands.PontoVenda.Usuario;
using Application.UseCases.Tools;
using Domain.Dtos;
using Domain.Entities.PontoVendaUser;
using Domain.Interfaces;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Handlers.PontoVenda.Usuario
{
    public class RegistrarUsuarioPontoVendaHandler : IHandler<RegistrarUsuarioPontoVendaCommand>
    {
        private readonly IBaseRepository<UsuarioPontoVendaEntity> _repository;

        public RegistrarUsuarioPontoVendaHandler(IBaseRepository<UsuarioPontoVendaEntity> repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult> Handler(RegistrarUsuarioPontoVendaCommand command, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = EntityMapper.ParceUsuarioPontoVendaEntity(command, users);
                if (!entity.Validada)
                    return new RequestResult().EntidadeInvalida();

                var entityResult = await _repository.InsertAsync(entity);
                if (entityResult == null)
                    return new RequestResult().BadRequest("Não foi possíve registrar usuário para ponto de venda.");

                return new RequestResult().Ok();
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

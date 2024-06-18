using Application.Results;
using Application.UseCases.Commands.User;
using Application.UseCases.Tools;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers.User
{
    public class UserIdentityHandler : IUserHandler<UserCreateCommand, UserUpdatePassword>
    {
        private readonly UserManager<UserEntity> _userManager;
        public UserIdentityHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RequestResult> Cadastrar(UserCreateCommand command)
        {
            try
            {
                var exists = await _userManager.Users.FirstOrDefaultAsync(u => u.Email!.Equals(command.Email));
                if (exists != null)
                    return new RequestResult().BadRequest("E-mail já está em uso");

                var entity = EntityMapper.ParceUserCreate(command);

                var userCreateResult = await _userManager.CreateAsync(entity, command.Senha);

                if (userCreateResult.Succeeded)
                {
                    var userCreate = await _userManager.SetLockoutEnabledAsync(entity, false);
                    return new RequestResult().Ok("Usuário criado com sucesso.");
                }

                return new RequestResult().BadRequest(userCreateResult.Errors.Select(r => r.Description).First());
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> AlterarSenha(UserUpdatePassword command)
        {
            try
            {
                var userExists = await _userManager.Users.Where(u => u.Id == command.IdUser).SingleOrDefaultAsync();
                if (userExists == null)
                    return new RequestResult().BadRequest("Usuário não localizado");

                var senhaTrocadaResult = await _userManager.ChangePasswordAsync(userExists, command.SenhaAntiga, command.NovaSenha);
                if (!senhaTrocadaResult.Succeeded)
                {
                    return new RequestResult().BadRequest(senhaTrocadaResult.Errors.Select(r => r.Description).First());
                }

                return new RequestResult().Ok("Senha altedada com sucesso");
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

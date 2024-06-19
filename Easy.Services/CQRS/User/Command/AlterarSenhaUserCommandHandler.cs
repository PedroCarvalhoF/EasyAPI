using Easy.Domain.Entities.User;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Easy.Services.CQRS.User.Command;

public class AlterarSenhaUserCommandHandler : IRequestHandler<AlterarSenhaUserCommand, RequestResult>
{
    private readonly UserManager<UserEntity> _userManager;
    public AlterarSenhaUserCommandHandler(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }
    public async Task<RequestResult> Handle(AlterarSenhaUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userExists = await _userManager.Users.Where(u => u.Id == request.IdUser).SingleOrDefaultAsync();
            if (userExists == null)
                return new RequestResult().BadRequest("Usuário não localizado");

            var senhaTrocadaResult = await _userManager.ChangePasswordAsync(userExists, request.SenhaAntiga, request.NovaSenha);
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

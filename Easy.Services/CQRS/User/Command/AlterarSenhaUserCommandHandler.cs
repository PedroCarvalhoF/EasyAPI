using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Easy.Services.CQRS.User.Command;

public class AlterarSenhaUserCommandHandler : IRequestHandler<AlterarSenhaUserCommand, RequestResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public AlterarSenhaUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RequestResult> Handle(AlterarSenhaUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userExists = await _unitOfWork.UserManager.Users.Where(u => u.Id == request.IdUser).SingleOrDefaultAsync();
            if (userExists == null)
                return new RequestResult().BadRequest("Usuário não localizado");

            var senhaTrocadaResult = await _unitOfWork.UserManager.ChangePasswordAsync(userExists, request.SenhaAntiga, request.NovaSenha);
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

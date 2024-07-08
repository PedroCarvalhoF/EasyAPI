using Easy.Services.DTOs;
using Easy.Services.DTOs.UserIdentity;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Easy.Services.CQRS.User.Command;

public class UserLoginCommand : IRequest<RequestResult<UsuarioLoginResponse>>
{
    public UserLoginCommand(string? email, string? senha)
    {
        Email = email;
        Senha = senha;
    }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string? Email { get; private set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Senha { get; private set; }
}

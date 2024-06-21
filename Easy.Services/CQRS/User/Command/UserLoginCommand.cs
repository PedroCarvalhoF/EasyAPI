using Easy.Domain.Entities.UserMasterUser;
using Easy.Services.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Easy.Services.CQRS.User.Command;

public class UserLoginCommand : IRequest<RequestResult>
{
    public UserLoginCommand(string? email, string? senha, UserMasterUserEntity user)
    {
        Email = email;
        Senha = senha;
        Users = user;
    }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string? Email { get; private set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Senha { get; private set; }
    public UserMasterUserEntity Users { get; private set; }
}

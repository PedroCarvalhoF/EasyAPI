using Easy.Domain.Entities;
using Easy.Services.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Easy.Services.CQRS.User.Command;

public class UserLoginCommand : IRequest<RequestResult>
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

    FiltroBase Filtro { get;  set; }
    public void AplicarFiltro(FiltroBase filtro)
        => Filtro = filtro;

}

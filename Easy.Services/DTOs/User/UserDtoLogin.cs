using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User;

public class UserDtoLogin
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string? Email { get; private set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Senha { get; private set; }
    public UserDtoLogin(string? email, string? senha)
    {
        Email = email;
        Senha = senha;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User;

public class UserDtoUpdateNomeSobreNome
{
    [Required]
    public string Nome { get; private set; }
    [Required]
    public string SobreNome { get; private set; }
    [Required]
    [EmailAddress]
    public string Email { get; private set; }
    public UserDtoUpdateNomeSobreNome(string nome, string sobreNome, string email)
    {
        Nome = nome;
        SobreNome = sobreNome;
        Email = email;
    }
}

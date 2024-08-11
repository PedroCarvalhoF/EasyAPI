using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User;

public class UserDtoUpdateSenha
{
    public UserDtoUpdateSenha(string email, string senhaAntiga, string novaSenha, string confirmPassword)
    {
        this.email = email;
        SenhaAntiga = senhaAntiga;
        NovaSenha = novaSenha;
        ConfirmPassword = confirmPassword;
    }

    [Required]
    [EmailAddress]
    public string email { get; private set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Senha Antiga.")]
    public string SenhaAntiga { get; private set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Nova Senha.")]
    public string NovaSenha { get; private set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirma Nova Senha")]
    [Compare("NovaSenha", ErrorMessage = "As senhas não combinão.")]
    public string ConfirmPassword { get; private set; }
}

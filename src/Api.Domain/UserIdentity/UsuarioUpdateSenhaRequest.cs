using System.ComponentModel.DataAnnotations;

namespace Domain.UserIdentity
{
    public class UsuarioUpdateSenhaRequest
    {
        [Required]
        [Display(Name = "Id do Usuario")]
        public Guid IdUser { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Antiga.")]
        public string? SenhaAntiga { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha.")]
        public string? NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma Nova Senha")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não combinão.")]
        public string? ConfirmPassword { get; set; }
    }
}

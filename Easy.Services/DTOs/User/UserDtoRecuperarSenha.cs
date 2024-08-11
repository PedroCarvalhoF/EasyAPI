using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User
{
    public class UserDtoRecuperarSenha
    {
        public UserDtoRecuperarSenha(string email, string token, string novaSenha)
        {
            this.Email = email;
            this.Token = token;
            NovaSenha = novaSenha;
        }

        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string Token { get; private set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha.")]
        public string NovaSenha { get; private set; }
    }
}

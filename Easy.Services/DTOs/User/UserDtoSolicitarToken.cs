using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User
{
    public class UserDtoSolicitarToken
    {
        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        public UserDtoSolicitarToken(string email)
        {
            Email = email;
        }
    }
}

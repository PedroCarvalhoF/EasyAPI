using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User
{
    public class UserDtoRequestEmail
    {
        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        public UserDtoRequestEmail(string email)
        {
            Email = email;
        }
    }
}

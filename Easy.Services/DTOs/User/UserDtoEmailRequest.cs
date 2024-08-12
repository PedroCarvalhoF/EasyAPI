using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User
{
    public class UserDtoEmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        public UserDtoEmailRequest(string email)
        {
            Email = email;
        }
    }
}

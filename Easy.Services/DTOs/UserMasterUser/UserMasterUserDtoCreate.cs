using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.UserMasterUser
{
    public class UserMasterUserDtoCreate
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

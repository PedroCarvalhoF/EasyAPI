using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.UserMasterUser
{
    public class UserMasterUserDtoCreate
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}

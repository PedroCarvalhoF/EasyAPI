using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.UserMaster
{
    public class UserMasterClienteDtoCreate
    {
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        public UserMasterClienteDtoCreate(string email)
        {
            Email = email;
        }
    }
}

using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserMasterUser;

namespace Easy.Services.DTOs.UserMaster
{
    public class UserMasterClienteDto
    {
        public virtual UserDto? UserMaster { get; set; }
        public virtual ICollection<UserMasterUserDto>? UsersMasterUsers { get; set; }
    }
}
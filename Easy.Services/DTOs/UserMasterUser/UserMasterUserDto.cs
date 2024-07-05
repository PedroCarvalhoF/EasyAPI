using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserMaster;

namespace Easy.Services.DTOs.UserMasterUser
{
    public class UserMasterUserDto
    {
        public virtual UserMasterClienteDto? UserCliente { get; set; }
        public virtual UserDto? UserMasterUser { get; set; }
    }
}

using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserMaster;

namespace Easy.Services.DTOs.UserMasterUser
{
    public class UserMasterUserView
    {
        public virtual UserMasterClienteView? UserCliente { get; set; }
        public virtual UserView? UserMasterUser { get; set; }
    }
}

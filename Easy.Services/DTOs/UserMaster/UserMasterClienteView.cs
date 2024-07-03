using Easy.Services.DTOs.User;
using Easy.Services.DTOs.UserMasterUser;

namespace Easy.Services.DTOs.UserMaster
{
    public class UserMasterClienteView
    {
        public virtual UserView? UserMaster { get; private set; }
        public virtual ICollection<UserMasterUserView>? UsersMasterUsers { get; private set; }
    }
}
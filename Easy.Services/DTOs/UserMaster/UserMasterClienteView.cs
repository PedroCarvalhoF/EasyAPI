using Easy.Services.DTOs.User;

namespace Easy.Services.DTOs.UserMaster
{
    public class UserMasterClienteView
    {
        public virtual UserView? UserMaster { get; private set; }
        public virtual ICollection<UserMasterUserView>? UsersMasterUsers { get; private set; }
    }
}
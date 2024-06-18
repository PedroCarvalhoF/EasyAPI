using Application.DTOs.User;
using Application.DTOs.UserMasterUser;

namespace Application.DTOs.UserMaster
{
    public class UserMasterClienteView
    {       
        public virtual UserView? UserMaster { get; private set; }
        public virtual ICollection<UserMasterUserView>? UsersMasterUsers { get; private set; }
    }
}
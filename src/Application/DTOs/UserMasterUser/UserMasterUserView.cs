using Application.DTOs.User;
using Application.DTOs.UserMaster;

namespace Application.DTOs.UserMasterUser
{
    public class UserMasterUserView
    {        
        public virtual UserMasterClienteView? UserCliente { get; set; }       
        public virtual UserView? UserMasterUser { get; set; }
    }
}

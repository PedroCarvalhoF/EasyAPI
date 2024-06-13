using Domain.Identity.UserIdentity;
using Domain.UserIdentity.MasterUsers;

namespace Domain.UserIdentity.Masters
{
    public class UserMasterClienteEntity
    {
        public Guid UserMasterId { get; set; }
        public virtual User? UserMaster { get; set; }
        public virtual ICollection<UserMasterUserEntity>? UsersMasterUsers { get; set; }
    }
}

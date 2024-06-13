using Domain.Identity.UserIdentity;
using Domain.UserIdentity.Masters;

namespace Domain.UserIdentity.MasterUsers
{
    public class UserMasterUserEntity
    {
        public Guid UserMasterClienteIdentityId { get; set; }
        public virtual UserMasterClienteEntity? UserMasterClienteIdentity { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}

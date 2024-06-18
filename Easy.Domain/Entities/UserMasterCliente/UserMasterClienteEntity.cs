using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterUser;

namespace Easy.Domain.Entities.UserMasterCliente
{
    public class UserMasterClienteEntity
    {
        public Guid UserMasterId { get; private set; }
        public virtual UserEntity? UserMaster { get; private set; }
        public virtual ICollection<UserMasterUserEntity>? UsersMasterUsers { get; private set; }
        public bool IsValid => Validate();

        private bool Validate()
        {
            return UserMasterId != Guid.Empty;
        }
        UserMasterClienteEntity(Guid userMasterId)
        {

            if (userMasterId == Guid.Empty)
                throw new ArgumentException("UserMasterId cannot be empty.", nameof(userMasterId));

            UserMasterId = userMasterId;
        }

        public static UserMasterClienteEntity Create(Guid userMasterId)
            => new UserMasterClienteEntity(userMasterId);
    }
}
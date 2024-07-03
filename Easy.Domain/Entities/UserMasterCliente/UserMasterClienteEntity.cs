using Easy.Domain.Entities.User;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.UserMasterCliente
{
    public class UserMasterClienteEntity
    {
        public Guid UserMasterId { get; private set; }
        public virtual UserEntity? UserMaster { get; set; }
        public virtual ICollection<UserMasterUserEntity>? UsersMasterUsers { get; private set; }
        public bool IsValid => Validate();

        private bool Validate()
        {
            return UserMasterId != Guid.Empty;
        }
        public UserMasterClienteEntity() { }
        public UserMasterClienteEntity(Guid userMasterId)
        {
            DomainValidation.When(userMasterId == Guid.Empty, "Informe o UserMasterId");

            UserMasterId = userMasterId;
        }
    }
}
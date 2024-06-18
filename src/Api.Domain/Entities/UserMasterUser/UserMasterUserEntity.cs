using Domain.Entities.User;
using Domain.Entities.UserMasterCliente;

namespace Domain.Entities.UserMasterUser
{
    public class UserMasterUserEntity
    {
        public Guid UserClienteId { get; private set; }
        public virtual UserMasterClienteEntity? UserCliente { get; private set; }
        public Guid? UserMasterUserId { get; private set; }
        public virtual UserEntity? UserMasterUser { get; private set; }

        public bool isValid => Validar();

        private bool Validar()
        {
            if (UserClienteId == Guid.Empty || UserMasterUserId == Guid.Empty)
                return false;

            return true;
        }

        UserMasterUserEntity(Guid userClienteId, Guid? userMasterUserId)
        {
            if (userClienteId == Guid.Empty || userMasterUserId == Guid.Empty)
                throw new Exception("Necessário o idMaster e IdUser");

            UserClienteId = userClienteId;
            UserMasterUserId = userMasterUserId;
        }

        public static UserMasterUserEntity Create(Guid userClienteId, Guid? userMasterUserId)
            => new UserMasterUserEntity(userClienteId, userMasterUserId);

    }
}

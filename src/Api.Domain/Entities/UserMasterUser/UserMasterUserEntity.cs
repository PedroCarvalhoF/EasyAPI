using Api.Domain.Entities;
using Domain.Entities.User;
using Domain.Entities.UserMasterCliente;

namespace Domain.Entities.UserMasterUser
{
    public class UserMasterUserEntity
    {
        public Guid UserClienteId { get; set; }
        public virtual UserMasterClienteEntity? UserCliente { get; set; }
        public virtual Guid? UserMasterUserId { get; set; }
        public virtual UserEntity? UserMasterUser { get; set; }
        public virtual ICollection<BaseEntity>? BaseEntities { get; set; }
    }
}

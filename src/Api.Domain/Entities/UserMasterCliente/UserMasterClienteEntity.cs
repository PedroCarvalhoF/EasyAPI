using Api.Domain.Entities;
using Domain.Entities.User;
using Domain.Entities.UserMasterUser;

namespace Domain.Entities.UserMasterCliente
{
    public class UserMasterClienteEntity
    {
        public Guid UserMasterId { get; set; }
        public virtual UserEntity? UserMaster { get; set; }
        public virtual ICollection<UserMasterUserEntity>? UsersMasterUsers { get; set; }
       
    }
}
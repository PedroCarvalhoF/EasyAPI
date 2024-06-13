using Domain.Entities.PontoVendaUser;
using Domain.UserIdentity.Masters;
using Domain.UserIdentity.MasterUsers;
using Microsoft.AspNetCore.Identity;


namespace Domain.Identity.UserIdentity
{
    public class User : IdentityUser<Guid>
    {
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
        public string? ImagemURL { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual UsuarioPontoVendaEntity? UsuarioPontoVendaEntity { get; set; }
        public virtual UserMasterClienteEntity? UsuerMasterCliente { get; set; }
        public virtual ICollection<UserMasterUserEntity>? UsersMasters { get; set; }

    }
}
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Entities.User
{
    public class UserEntity : IdentityUser<Guid>
    {
        UserEntity(string nome, string sobreNome, string userName, string email)
        {
            Nome = nome;
            SobreNome = sobreNome;
            UserName = email;
            Email = email;
            EmailConfirmed = true;
            ImagemURL = string.Empty;
        }

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string ImagemURL { get; private set; }
        public virtual ICollection<UserRoleEntity>? UserRoles { get; set; }
        public virtual UserMasterClienteEntity? UserMasterCliente { get; set; }
        public virtual UserMasterUserEntity? UserMasterUser { get; set; }

        public static UserEntity CreateUser(string nome, string sobreNome, string userName, string email)
            => new UserEntity(nome, sobreNome, userName, email);
    }
}

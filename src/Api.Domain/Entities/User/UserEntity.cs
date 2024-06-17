using Domain.Entities.UserMasterCliente;
using Domain.Entities.UserMasterUser;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class UserEntity : IdentityUser<Guid>
    {
        UserEntity(string nome, string sobreNome, string imagemURL)
        {
            Nome = nome;
            SobreNome = sobreNome;
            ImagemURL = imagemURL;
        }

        public string? Nome { get; private set; }
        public string? SobreNome { get; private set; }
        public string? ImagemURL { get; private set; }
        public virtual ICollection<UserRoleEntity>? UserRoles { get; set; }
        public virtual UserMasterClienteEntity? UserMasterCliente { get; set; }
        public virtual UserMasterUserEntity? UserMasterUser { get; set; }

        public static UserEntity CreateUser(string nome, string sobreNome, string imagemURL)
            => new UserEntity(nome, sobreNome, imagemURL);
    }
}

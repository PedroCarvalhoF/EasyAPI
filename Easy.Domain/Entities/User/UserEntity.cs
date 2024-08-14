using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Entities.UserMasterCliente;
using Easy.Domain.Entities.UserMasterUser;
using Easy.Domain.Tools.Validation;
using Microsoft.AspNetCore.Identity;

namespace Easy.Domain.Entities.User
{
    public class UserEntity : IdentityUser<Guid>
    {
        public UserEntity() { }
        public UserEntity(string nome, string sobreNome, string userName, string email, string imageName = "sem-foto.png")
        {
            DomainValidation.When(string.IsNullOrEmpty(nome), "Informe o nome");
            DomainValidation.When(string.IsNullOrEmpty(sobreNome), "Informe o sobre nome");
            DomainValidation.When(string.IsNullOrEmpty(userName), "Informe o user name");
            DomainValidation.When(string.IsNullOrEmpty(email), "Informe o e-mail");

            Nome = nome;
            SobreNome = sobreNome;
            UserName = email;
            Email = email;
            EmailConfirmed = true;


            if (string.IsNullOrEmpty(imageName))
            {
                ImagemURL = "sem-foto.png";
            }
            else
                ImagemURL = imageName;
        }

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string ImagemURL { get; private set; }
        public virtual ICollection<UserRoleEntity>? UserRoles { get; private set; }
        public virtual UserMasterClienteEntity? UserMasterCliente { get; private set; }
        public virtual UserMasterUserEntity? UserMasterUser { get; private set; }
        public virtual UsuarioPdvEntity? UsuarioPdv { get; private set; }

        public static UserEntity CreateUser(string nome, string sobreNome, string userName, string email, string imageName)
            => new UserEntity(nome, sobreNome, userName, email, imageName);

        public void AlterarNomeSobreNome(string nome, string sobreNome)
        {
            Nome = nome;
            SobreNome = sobreNome;
        }

        public void AlterarUrlImage(string imageUrl)
        {
            ImagemURL = imageUrl;
        }
    }
}

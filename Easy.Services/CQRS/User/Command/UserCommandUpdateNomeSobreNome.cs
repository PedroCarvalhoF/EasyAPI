using Easy.Services.DTOs.User;

namespace Easy.Services.CQRS.User.Command
{
    public class UserCommandUpdateNomeSobreNome : BaseCommands<UserDto>
    {
        public UserDtoUpdateNomeSobreNome UserDtoUpdate { get; private set; }

        public UserCommandUpdateNomeSobreNome(UserDtoUpdateNomeSobreNome userDtoUpdate)
        {
            UserDtoUpdate = userDtoUpdate;
        }
    }
}

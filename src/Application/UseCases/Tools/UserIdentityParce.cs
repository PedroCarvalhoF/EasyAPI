using Application.UseCases.Commands.User;
using Domain.Entities.User;

namespace Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static UserEntity ParceUserCreate(UserCreateCommand command)
        {
            return UserEntity
                .CreateUser(nome: command.Nome,
                       sobreNome: command.SobreNome,
                        userName: command.Email,
                           email: command.Email);
        }

    }
}

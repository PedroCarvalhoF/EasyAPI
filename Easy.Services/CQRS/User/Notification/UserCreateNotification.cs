using Easy.Domain.Entities.User;
using MediatR;

namespace Easy.Services.CQRS.User.Notification;

public class UserCreateNotification : INotification
{
    public UserEntity User { get; }
    public UserCreateNotification(UserEntity user)
    {
        User = user;
    }
    public override string ToString()
    {
        return $"Usuário: {User.Nome} {User.SobreNome} E-mail: {User.Email}";
    }
}

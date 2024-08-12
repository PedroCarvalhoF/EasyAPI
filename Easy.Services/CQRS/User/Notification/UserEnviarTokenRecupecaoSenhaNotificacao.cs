using MediatR;
using Microsoft.Extensions.Logging;

namespace Easy.Services.CQRS.User.Notification;

public class UserEnviarTokenRecupecaoSenhaNotificacao : INotification
{
    public string Token { get; private set; }

    public UserEnviarTokenRecupecaoSenhaNotificacao(string token)
    {
        Token = token;
    }

    public override string ToString()
    {
        return $"Token criado {Token}";
    }

    public class UserEnviarTokenRecupecaoSenhaNotificacaoHandler : INotificationHandler<UserEnviarTokenRecupecaoSenhaNotificacao>
    {
        private readonly ILogger<UserCreateEmailHandler> _logger;

        public UserEnviarTokenRecupecaoSenhaNotificacaoHandler(ILogger<UserCreateEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserEnviarTokenRecupecaoSenhaNotificacao notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(notification.ToString());

            return Task.CompletedTask;
        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;

namespace Easy.Services.CQRS.User.Notification;

public class UserCreateEmailHandler : INotificationHandler<UserCreateNotification>
{
    private readonly ILogger<UserCreateEmailHandler> _logger;

    public UserCreateEmailHandler(ILogger<UserCreateEmailHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserCreateNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(notification.ToString());

        return Task.CompletedTask;
    }
}

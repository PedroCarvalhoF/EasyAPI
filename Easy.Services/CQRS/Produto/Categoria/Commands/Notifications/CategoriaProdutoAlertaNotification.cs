using MediatR;
using Microsoft.Extensions.Logging;

namespace Easy.Services.CQRS.Produto.Categoria.Commands.Notifications;

public class CategoriaProdutoAlertaNotification : INotificationHandler<CategoriaProdutoCreatedNotification>
{
    private readonly ILogger<CategoriaProdutoAlertaNotification>? _logger;

    public CategoriaProdutoAlertaNotification(ILogger<CategoriaProdutoAlertaNotification>? logger)
    {
        _logger = logger;
    }

    public Task Handle(CategoriaProdutoCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Categoria {notification.CategoriaProdutoEntity.DescricaoCategoria} criada com sucesso as {DateTime.Now}");

        //lógica para enviar email   

        return Task.CompletedTask;
    }
}

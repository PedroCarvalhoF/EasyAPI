using Easy.Domain.Entities.Produto.CategoriaProduto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Commands.Notifications;

public class CategoriaProdutoCreatedNotification : INotification
{
    public CategoriaProdutoEntity CategoriaProdutoEntity { get; }

    public CategoriaProdutoCreatedNotification(CategoriaProdutoEntity categoriaProdutoEntity)
    {
        CategoriaProdutoEntity = categoriaProdutoEntity;
    }
}

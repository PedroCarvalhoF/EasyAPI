using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands;

public class ProdutoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<ProdutoUpdateCommand, RequestResultForUpdate>
{
    public async Task<RequestResultForUpdate> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var produtoUpdateEntity = ProdutoEntity.Update(request.Id, request.Habilitado, request.NomeProduto, request.Codigo, request.Descricao, request.Observacoes, request.ImagemUrl, request.CategoriaProdutoEntityId, request.MedidaProdutoEnum, request.TipoProdutoEnum, request.GetFiltro());

            await _repository.ProdutoRepository.UpdateAsync(produtoUpdateEntity, request.GetFiltro());
            var commitResult = await _repository.CommitAsync();
            if (commitResult)
                return new RequestResultForUpdate().Ok("Produto alterado.");

            return new RequestResultForUpdate().Ok("Não foi possível realizar alteração");
        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
    }
}

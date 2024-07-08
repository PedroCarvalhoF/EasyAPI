using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands;

public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, RequestResultForUpdate>
{
    private readonly IUnitOfWork _repository;
    public ProdutoCreateCommandHandler(IUnitOfWork uow)
    {
        _repository = uow;
    }

    public async Task<RequestResultForUpdate> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var produtoEntity = ProdutoEntity.Create(request.NomeProduto, request.Codigo, request.Descricao, request.Observacoes, request.ImagemUrl, request.CategoriaProdutoEntityId, request.MedidaProdutoEnum, request.TipoProdutoEnum, request.GetFiltro());

            await _repository.ProdutoRepository.InsertAsync(produtoEntity, request.GetFiltro());
            var resultCommit = await _repository.CommitAsync();

            if (resultCommit)
                return new RequestResultForUpdate().Ok("Produto criado com sucesso.");

            return new RequestResultForUpdate().BadRequest("Não foi possível cadastrar");
        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
    }
}

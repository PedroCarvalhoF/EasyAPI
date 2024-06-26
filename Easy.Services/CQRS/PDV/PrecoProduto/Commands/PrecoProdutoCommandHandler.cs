using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Commands;

public class PrecoProdutoCommandHandler(IUnitOfWork _repository) : IRequestHandler<PrecoProdutoCommand, RequestResult>
{
    public async Task<RequestResult> Handle(PrecoProdutoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var users = request.GetFiltro();

            var precoProdutoExists = await
                _repository.PrecoProdutoRepository.SelectAsync(request.ProdutoEntityId, request.CategoriaPrecoEntityId, users);

            if (precoProdutoExists is null)
            {
                var precoProdutoCreate = PrecoProdutoEntity.Create(request.ProdutoEntityId, request.CategoriaPrecoEntityId, request.Preco, users);

                if (!precoProdutoCreate.isBaseValida)
                    return new RequestResult().EntidadeInvalida();

                await _repository.PrecoProdutoRepository.InsertAsync(precoProdutoCreate, users);
                if (await _repository.CommitAsync())
                    return new RequestResult().Ok("Preco cadastrado com sucesso!");
            }
            else
            {
                var precoProdutoUpdate = PrecoProdutoEntity.Update(precoProdutoExists.Id, true, precoProdutoExists.ProdutoEntityId, precoProdutoExists.CategoriaPrecoEntityId, request.Preco, users);

                if (!precoProdutoUpdate.isBaseValida)
                    return new RequestResult().EntidadeInvalida();

                await _repository.PrecoProdutoRepository.UpdatePreco(precoProdutoUpdate, users);
                if (await _repository.CommitAsync())
                    return new RequestResult().Ok("Preço alterado com sucesso!");
            }


            return new RequestResult().BadRequest();

        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}

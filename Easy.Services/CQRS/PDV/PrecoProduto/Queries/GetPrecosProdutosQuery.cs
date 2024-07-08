using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Queries;

public class GetPrecosProdutosQuery : BaseCommandsForUpdate
{

    public class GetPrecosProdutosQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPrecosProdutosQuery, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetPrecosProdutosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var precosProdutoEntities = await _repository.PrecoProdutoRepository.SelectAsync(filtro);
                return new RequestResultForUpdate().Ok(precosProdutoEntities);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

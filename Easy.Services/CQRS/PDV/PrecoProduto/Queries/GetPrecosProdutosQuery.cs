using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Queries;

public class GetPrecosProdutosQuery : BaseCommands
{

    public class GetPrecosProdutosQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPrecosProdutosQuery, RequestResult>
    {
        public async Task<RequestResult> Handle(GetPrecosProdutosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var precosProdutoEntities = await _repository.PrecoProdutoRepository.SelectAsync(filtro);
                return new RequestResult().Ok(precosProdutoEntities);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

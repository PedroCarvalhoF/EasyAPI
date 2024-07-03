using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.Produto.Queries;

public class GetProdutosQuery : IRequest<RequestResult>
{
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetProdutosQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetProdutosQuery, RequestResult>
    {

        public async Task<RequestResult> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _unitOfWork.ProdutoRepository.SelectAsync(request.GetFiltro());

            return new RequestResult().Ok(produtos);
        }
    }
}

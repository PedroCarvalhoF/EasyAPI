using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.Produto.Queries;

public class GetProdutoByIdQuery : IRequest<RequestResult>
{
    public Guid IdProduto { get; set; }
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetProdutoByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetProdutoByIdQuery, RequestResult>
    {
        public async Task<RequestResult> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _repository.ProdutoRepository.SelectAsync(request.IdProduto, request.GetFiltro());
                if (produto != null)
                    return new RequestResult().Ok(produto);

                return new RequestResult().BadRequest("Produto não localizado");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

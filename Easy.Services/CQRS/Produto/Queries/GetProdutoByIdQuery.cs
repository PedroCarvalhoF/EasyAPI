using AutoMapper;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Queries;

public class GetProdutoByIdQuery : BaseCommands<ProdutoDto>
{
    public Guid IdProduto { get; set; }
    public class GetProdutoByIdQueryHandler(IUnitOfWork _repository, IMapper _mapper) : IRequestHandler<GetProdutoByIdQuery, RequestResult<ProdutoDto>>
    {

        public async Task<RequestResult<ProdutoDto>> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoEntity = await _repository.ProdutoRepository.SelectAsync(request.IdProduto, request.GetFiltro());
                if (produtoEntity is null)
                    return RequestResult<ProdutoDto>.BadRequest("Produto não localizado");

                var produtoDto = _mapper.Map<ProdutoDto>(produtoEntity);

                return RequestResult<ProdutoDto>.Ok(produtoDto);
            }
            catch (Exception ex)
            {

                return RequestResult<ProdutoDto>.BadRequest(ex.Message);
            }
        }
    }
}

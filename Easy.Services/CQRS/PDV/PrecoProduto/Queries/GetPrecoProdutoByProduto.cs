using AutoMapper;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PrecoProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Queries
{
    public class GetPrecoProdutoByProduto : BaseCommands<List<PrecoProdutoDtoView>>
    {
        public Guid IdProduto { get; set; }

        public class GetPrecoProdutoByProdutoHandler : IRequestHandler<GetPrecoProdutoByProduto, RequestResult<List<PrecoProdutoDtoView>>>
        {
            private readonly IUnitOfWork _repository;
            private readonly IMapper _mapper;

            public GetPrecoProdutoByProdutoHandler(IUnitOfWork repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<RequestResult<List<PrecoProdutoDtoView>>> Handle(GetPrecoProdutoByProduto request, CancellationToken cancellationToken)
            {
                try
                {
                    var precoProdutoEntities = await _repository.PrecoProdutoRepository.SelectPrecosByIdProdutoAsync(request.IdProduto, request.GetFiltro());


                    List<PrecoProdutoDtoView> listaPrecoProdutoView = new List<PrecoProdutoDtoView>();

                    foreach (var pr in precoProdutoEntities)
                    {
                        var precoView = DtoMapper.ParcePrecoProduto(pr);
                        listaPrecoProdutoView.Add(precoView);
                    }

                    return RequestResult<List<PrecoProdutoDtoView>>.Ok(listaPrecoProdutoView ?? new List<PrecoProdutoDtoView>());
                }
                catch (Exception ex)
                {

                    return RequestResult<List<PrecoProdutoDtoView>>.BadRequest(ex.Message);
                }
            }
        }
    }
}

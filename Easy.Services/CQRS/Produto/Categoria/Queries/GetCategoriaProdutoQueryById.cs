using AutoMapper;
using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Queries;

public class GetCategoriaProdutoQueryById : BaseCommands<CategoriaProdutoView>
{
    public GetCategoriaProdutoQueryById(Guid idCategoria)
    {
        IdCategoria = idCategoria;
    }

    public Guid IdCategoria { get; private set; }
    public class GetCategoriaProdutoQueryByIdHandler : IRequestHandler<GetCategoriaProdutoQueryById, RequestResult<CategoriaProdutoView>>
    {
        private readonly ICategoriaProdutoDapperRepository<FiltroBase> _repository;
        private readonly IMapper _mapper;

        public GetCategoriaProdutoQueryByIdHandler(ICategoriaProdutoDapperRepository<FiltroBase> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResult<CategoriaProdutoView>> Handle(GetCategoriaProdutoQueryById request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaProdutoEntity = await _repository.GetCategoriaProdutoById(request.IdCategoria, request.GetFiltro());
                if (categoriaProdutoEntity == null)
                    return RequestResult<CategoriaProdutoView>.BadRequest("Categoria do produto não foi localizada.");

                var categoriaProdutoDto = _mapper.Map<CategoriaProdutoView>(categoriaProdutoEntity);

                return RequestResult<CategoriaProdutoView>.Ok(categoriaProdutoDto, "Categoria do produto localizada.");
            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaProdutoView>.BadRequest(ex.Message);
            }
        }
    }
}

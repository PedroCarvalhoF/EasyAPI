using AutoMapper;
using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Queries;

public class GetCategoriaProdutoQuery : BaseCommands<IEnumerable<CategoriaProdutoView>>
{
    public class GetCategoriaQueryHandler : IRequestHandler<GetCategoriaProdutoQuery, RequestResult<IEnumerable<CategoriaProdutoView>>>
    {
        //FUTURAMENTE UTILIZAR DAPPER
        private readonly ICategoriaProdutoDapperRepository<FiltroBase> _repository;
        private readonly IMapper _mapper;

        public GetCategoriaQueryHandler(ICategoriaProdutoDapperRepository<FiltroBase> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RequestResult<IEnumerable<CategoriaProdutoView>>> Handle(GetCategoriaProdutoQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetCategoriaProdutoEnity(request.GetFiltro());
            var dtos = _mapper.Map<ICollection<CategoriaProdutoView>>(entities);
            return RequestResult<IEnumerable<CategoriaProdutoView>>.Ok(dtos, "Consulta realizada com sucesso.");
        }
    }
}

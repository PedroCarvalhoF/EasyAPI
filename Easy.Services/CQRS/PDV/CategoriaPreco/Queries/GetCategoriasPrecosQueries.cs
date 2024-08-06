using AutoMapper;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriasPrecosQueries : BaseCommands<IEnumerable<CategoriaPrecoDtoView>>
{
    public class GetCategoriasPrecosQueriesHandler(IUnitOfWork _repository, IMapper _mapper) : IRequestHandler<GetCategoriasPrecosQueries, RequestResult<IEnumerable<CategoriaPrecoDtoView>>>
    {
        public async Task<RequestResult<IEnumerable<CategoriaPrecoDtoView>>> Handle(GetCategoriasPrecosQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriasPrecosEntities = await _repository.CategoriaPrecoRepository.SelectAsync(request.GetFiltro());
                var dtos = _mapper.Map<IEnumerable<CategoriaPrecoDtoView>>(categoriasPrecosEntities);
                return RequestResult<IEnumerable<CategoriaPrecoDtoView>>.Ok(dtos);
            }
            catch (Exception ex)
            {

                return RequestResult<IEnumerable<CategoriaPrecoDtoView>>.BadRequest(ex.Message);
            }
        }
    }
}

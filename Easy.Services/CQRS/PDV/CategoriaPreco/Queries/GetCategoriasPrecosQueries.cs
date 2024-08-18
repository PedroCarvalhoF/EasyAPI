using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriasPrecosQueries : BaseCommands<IEnumerable<CategoriaPrecoDto>>
{
    public class GetCategoriasPrecosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetCategoriasPrecosQueries, RequestResult<IEnumerable<CategoriaPrecoDto>>>
    {
        public async Task<RequestResult<IEnumerable<CategoriaPrecoDto>>> Handle(GetCategoriasPrecosQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriasPrecosEntities = await _repository.CategoriaPrecoRepository.GetAllAsync(request.GetFiltro());
                var dtos = DtoMapper.ParceCategoriasPrecosDto(categoriasPrecosEntities);
                return RequestResult<IEnumerable<CategoriaPrecoDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {

                return RequestResult<IEnumerable<CategoriaPrecoDto>>.BadRequest(ex.Message);
            }
        }
    }
}

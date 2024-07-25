using AutoMapper;
using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriasPrecosQueries : IRequest<RequestResultForUpdate>
{
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetCategoriasPrecosQueriesHandler(IUnitOfWork _repository, IMapper _mapper) : IRequestHandler<GetCategoriasPrecosQueries, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetCategoriasPrecosQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriasPrecosEntities = await _repository.CategoriaPrecoRepository.SelectAsync(request.GetFiltro());
                var dtos = _mapper.Map<IEnumerable<CategoriaPrecoDtoView>>(categoriasPrecosEntities);
                return new RequestResultForUpdate().Ok(dtos);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriasPrecosQueries : IRequest<RequestResultForUpdate>
{
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetCategoriasPrecosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetCategoriasPrecosQueries, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetCategoriasPrecosQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriasPrecosEntities = await _repository.CategoriaPrecoRepository.SelectAsync(request.GetFiltro());
                return new RequestResultForUpdate().Ok(categoriasPrecosEntities);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

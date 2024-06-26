using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriasPrecosQueries : IRequest<RequestResult>
{
    private FiltroBase FiltroBase { get; set; }
    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetCategoriasPrecosQueriesHandler(IUnitOfWork _repository) : IRequestHandler<GetCategoriasPrecosQueries, RequestResult>
    {
        public async Task<RequestResult> Handle(GetCategoriasPrecosQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriasPrecosEntities = await _repository.CategoriaPrecoRepository.SelectAsync(request.GetFiltro());
                return new RequestResult().Ok(categoriasPrecosEntities);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

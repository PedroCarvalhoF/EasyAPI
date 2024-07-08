using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriaPrecoByIdQuery : IRequest<RequestResultForUpdate>
{
    private FiltroBase FiltroBase { get; set; }
    public Guid Id { get; set; }

    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetCategoriaPrecoByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetCategoriaPrecoByIdQuery, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(GetCategoriaPrecoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriasPrecosEntities = await _repository.CategoriaPrecoRepository.SelectAsync(request.Id, request.GetFiltro());

                return new RequestResultForUpdate().Ok(categoriasPrecosEntities);
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

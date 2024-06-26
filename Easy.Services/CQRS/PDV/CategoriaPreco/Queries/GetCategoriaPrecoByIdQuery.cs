using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriaPrecoByIdQuery : IRequest<RequestResult>
{
    private FiltroBase FiltroBase { get; set; }
    public Guid Id { get; set; }

    public void SetUsers(FiltroBase user)
        => FiltroBase = user;
    public FiltroBase GetFiltro()
       => FiltroBase;

    public class GetCategoriaPrecoByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetCategoriaPrecoByIdQuery, RequestResult>
    {
        public async Task<RequestResult> Handle(GetCategoriaPrecoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriasPrecosEntities = await _repository.CategoriaPrecoRepository.SelectAsync(request.Id, request.GetFiltro());

                return new RequestResult().Ok(categoriasPrecosEntities);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

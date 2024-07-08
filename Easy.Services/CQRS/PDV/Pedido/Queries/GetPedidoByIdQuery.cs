using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Queries;

public class GetPedidoByIdQuery : BaseCommandsForUpdate
{
    public Guid Id { get; set; }

    public class GetPedidoByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPedidoByIdQuery, RequestResultForUpdate>
    {

        public async Task<RequestResultForUpdate> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {               
                return null;
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

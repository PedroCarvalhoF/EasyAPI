using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Queries;

public class GetPedidoByIdQuery : BaseCommands
{
    public Guid Id { get; set; }

    public class GetPedidoByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetPedidoByIdQuery, RequestResult>
    {

        public async Task<RequestResult> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {               
                return null;
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;
public class PedidoCancelarCommand : BaseCommandsForUpdate
{
    public Guid IdPedido { get; set; }

    public class PedidoCancelarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PedidoCancelarCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(PedidoCancelarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidoSelecionado = await _repository.PedidoBaseRepository.SelectAsync(request.IdPedido, filtro);
                if (pedidoSelecionado == null)
                    return new RequestResultForUpdate().BadRequest("Pedido não localizado");

                pedidoSelecionado.CancelarPedido();

                await _repository.PedidoBaseRepository.Update(pedidoSelecionado);

                if (!await _repository.CommitAsync())
                    return new RequestResultForUpdate().BadRequest("Não foi possível cancelar pedido");

                return new RequestResultForUpdate().Ok("Pedido cancelado.");
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

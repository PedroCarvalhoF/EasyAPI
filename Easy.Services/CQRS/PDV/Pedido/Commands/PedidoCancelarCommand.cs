using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;
public class PedidoCancelarCommand : BaseCommands
{
    public Guid IdPedido { get; set; }

    public class PedidoCancelarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PedidoCancelarCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(PedidoCancelarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidoSelecionado = await _repository.PedidoBaseRepository.SelectAsync(request.IdPedido, filtro);
                if (pedidoSelecionado == null)
                    return new RequestResult().BadRequest("Pedido não localizado");

                pedidoSelecionado.CancelarPedido();

                await _repository.PedidoBaseRepository.UpdateAsync(pedidoSelecionado, filtro);

                if (!await _repository.CommitAsync())
                    return new RequestResult().BadRequest("Não foi possível cancelar pedido");

                return new RequestResult().Ok("Pedido cancelado.");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

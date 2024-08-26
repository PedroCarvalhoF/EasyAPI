using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;

public class PedidoAtualizarCommand : BaseCommandsForUpdate
{
    public Guid IdPedido { get; set; }

    public class PedidoAtualizarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PedidoAtualizarCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(PedidoAtualizarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pedidoFiltro = new PedidoEntityFilter
                {
                    IdPedido = request.IdPedido,
                };

                var filtro = request.GetFiltro();

                var pedidos = await _repository.PedidoRepository.SelectAsync(pedidoFiltro, filtro);
                if (!pedidos.Any())
                    throw new ArgumentException("Pedido não localizado");
                var pedidoSelecionado = pedidos.Single();

                pedidoSelecionado.CalcularTotalPedido();

                if (!pedidoSelecionado.Validada)
                    return new RequestResultForUpdate().BadRequest("Erro ao validar pedido.");

                _repository.PedidoBaseRepository.Update(pedidoSelecionado);
                if (!await _repository.CommitAsync())
                    return new RequestResultForUpdate().BadRequest("Não foi possível atualizar pedido.");

                return new RequestResultForUpdate().Ok("Pedido atualizado.");
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}

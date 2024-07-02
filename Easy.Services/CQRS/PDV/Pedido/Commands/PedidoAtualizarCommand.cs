using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;

public class PedidoAtualizarCommand : BaseCommands
{
    public Guid IdPedido { get; set; }

    public class PedidoAtualizarCommandHandler(IUnitOfWork _repository) : IRequestHandler<PedidoAtualizarCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(PedidoAtualizarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pedidoFiltro = new PedidoEntityFilter
                {
                    IdPedido = request.IdPedido,
                    Include = true
                };

                var filtro = request.GetFiltro();

                var pedidos = await _repository.PedidoRepository.SelectAsync(pedidoFiltro, filtro);
                if (!pedidos.Any())
                    throw new ArgumentException("Pedido não localizado");
                var pedidoSelecionado = pedidos.Single();

                pedidoSelecionado.CalcularTotalPedido();

                if (!pedidoSelecionado.Validada)
                    return new RequestResult().BadRequest("Erro ao validar pedido.");

                await _repository.PedidoBaseRepository.UpdateAsync(pedidoSelecionado, filtro);
                if (!await _repository.CommitAsync())
                    return new RequestResult().BadRequest("Não foi possível atualizar pedido.");

                return new RequestResult().Ok("Pedido atualizado.");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

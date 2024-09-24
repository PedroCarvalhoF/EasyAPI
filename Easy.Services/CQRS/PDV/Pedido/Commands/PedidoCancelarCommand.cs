using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Service.Pedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;
public class PedidoCancelarCommand : BaseCommands<PedidoDto>
{
    public Guid IdPedido { get; set; }

    public class PedidoCancelarCommandHandler(IUnitOfWork _repository, IPedidoServices _pedidoServices) : IRequestHandler<PedidoCancelarCommand, RequestResult<PedidoDto>>
    {
        public async Task<RequestResult<PedidoDto>> Handle(PedidoCancelarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidoSelecionado = await _repository.PedidoBaseRepository.SelectAsync(request.IdPedido, filtro);
                if (pedidoSelecionado == null)
                    return RequestResult<PedidoDto>.BadRequest("Pedido não localizado");

                pedidoSelecionado.CancelarPedido();

                await _repository.PedidoBaseRepository.Update(pedidoSelecionado);

                if (!await _repository.CommitAsync())
                    return RequestResult<PedidoDto>.BadRequest("Não foi possível cancelar pedido");

                var pedidoDto = await _pedidoServices.GetPedidoById(pedidoSelecionado.Id, filtro);

                return RequestResult<PedidoDto>.Ok(pedidoDto, "Pedido cancelado com sucesso.");
            }
            catch (Exception ex)
            {
                return RequestResult<PedidoDto>.BadRequest(ex.Message);
            }
        }
    }
}

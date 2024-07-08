using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;

public class PedidoVendaCreateCommand : BaseCommandsForUpdate
{
    public string? NumeroPedido { get; set; }
    public Guid PontoVendaId { get; set; }
    public Guid CategoriaPrecoId { get; set; }

    public class PedidoVendaCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PedidoVendaCreateCommand, RequestResultForUpdate>
    {
        public async Task<RequestResultForUpdate> Handle(PedidoVendaCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidoVendaEntity = PedidoEntity.GerarPedidoVenda(request.NumeroPedido, request.PontoVendaId, request.CategoriaPrecoId, filtro);

                if (!pedidoVendaEntity.Validada)
                    return new RequestResultForUpdate().EntidadeInvalida();

                await _repository.PedidoBaseRepository.InsertAsync(pedidoVendaEntity);

                if (!await _repository.CommitAsync())
                    return new RequestResultForUpdate().BadRequest("Não foi possível gerar pedido venda");

                return new RequestResultForUpdate().Ok("Pedido de venda gereado com sucesso");
            }
            catch (Exception ex)
            {

                return new RequestResultForUpdate().BadRequest(ex.Message);
            }
        }
    }
}


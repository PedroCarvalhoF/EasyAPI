using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;

public class PedidoVendaCreateCommand : BaseCommands
{
    public string? NumeroPedido { get; set; }
    public Guid PontoVendaId { get; set; }
    public Guid CategoriaPrecoId { get; set; }

    public class PedidoVendaCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PedidoVendaCreateCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(PedidoVendaCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidoVendaEntity = PedidoEntity.GerarPedidoVenda(request.NumeroPedido, request.PontoVendaId, request.CategoriaPrecoId, filtro);

                if (!pedidoVendaEntity.Validada)
                    return new RequestResult().EntidadeInvalida();

                await _repository.PedidoBaseRepository.InsertAsync(pedidoVendaEntity);

                if (!await _repository.CommitAsync())
                    return new RequestResult().BadRequest("Não foi possível gerar pedido venda");

                return new RequestResult().Ok("Pedido de venda gereado com sucesso");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}


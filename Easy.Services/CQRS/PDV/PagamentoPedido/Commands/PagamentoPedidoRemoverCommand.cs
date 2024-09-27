using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PagamentoPedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.PagamentoPedido.Commands;

public class PagamentoPedidoRemoverCommand : BaseCommands<PagamentoPedidoDtoInserirResult>
{
    public required PagamentoPedidoDtoRemoverPagamentos PagamentoPedidoDtoRemoverPagamentos { get; set; }

    public class PagamentoPedidoRemoverCommandHandler(IUnitOfWork _repository) : IRequestHandler<PagamentoPedidoRemoverCommand, RequestResult<PagamentoPedidoDtoInserirResult>>
    {
        public async Task<RequestResult<PagamentoPedidoDtoInserirResult>> Handle(PagamentoPedidoRemoverCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var pedidoId = request.PagamentoPedidoDtoRemoverPagamentos.PedidoId;

                //validar pedido
                var pedidoEntity = await _repository.PedidoRepository.SelectAsync(new Domain.Entities.PDV.Pedido.PedidoEntityFilter
                {
                    IdPedido = pedidoId
                }, filtro, true);

                if (!pedidoEntity.Any())
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Pedido não localizado");

                if (!pedidoEntity.Single().Manipular)
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Não é possível manipular este pediddo.");


                var pagamentos = await _repository.PagamentoPedidoRespoitory.GetPagamentosByIdPedido(pedidoEntity.Single().Id, filtro);
                if (pagamentos == null || pagamentos.Count() == 0)
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Nenhum pagamento localizado para excluir");


                var revemoRange = await _repository.PagamentoPedidoBaseRepository.DeleteRange(pagamentos);
                if (!await _repository.CommitAsync())
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Não foi possível remover pagamentos");

                var result = new PagamentoPedidoDtoInserirResult(

                                pedidoId: pedidoEntity.Single().Id,
                        pedidoFinalizado: pedidoEntity.Single().Finalizado,
                              pagamentos: new List<PagamentoPedidoDto>(),
                                   troco: 0,
                             totalPedido: pedidoEntity.Single().Total);

                return RequestResult<PagamentoPedidoDtoInserirResult>.Ok(result);
            }
            catch (Exception ex)
            {

                return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest(ex.Message);
            }
        }

    }
}

using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PagamentoPedido;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PagamentoPedido.Commands;

public class PagamentoPedidoInserirCommand : BaseCommands<PagamentoPedidoDtoInserirResult>
{
    public required PagamentoPedidoDtoInserir PagamentoPedidoDtoInserir { get; set; }

    public class PagamentoPedidoInserirCommandHandler(IUnitOfWork _repository) : IRequestHandler<PagamentoPedidoInserirCommand, RequestResult<PagamentoPedidoDtoInserirResult>>
    {
        public async Task<RequestResult<PagamentoPedidoDtoInserirResult>> Handle(PagamentoPedidoInserirCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                //validar entidade pagamento do pedido
                var pagamentoPedidoEntity = PagamentoPedidoEntity.Inserir(request.PagamentoPedidoDtoInserir.FormaPagamentoId, request.PagamentoPedidoDtoInserir.PedidoId, request.PagamentoPedidoDtoInserir.ValorPago, filtro);
                if (!pagamentoPedidoEntity.Validada)
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Entidade invalida");

                //validar pedido
                var pedidoEntity = await _repository.PedidoRepository.SelectAsync(new Domain.Entities.PDV.Pedido.PedidoEntityFilter
                {
                    IdPedido = pagamentoPedidoEntity.PedidoId
                }, filtro, true);

                if (!pedidoEntity.Any())
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Pedido não localizado");

                if (!pedidoEntity.Single().Manipular || !pedidoEntity.Single().ReceberPagamentos)
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Não é possível manipular este pediddo.");


                var total_pago = pedidoEntity.Single().ValorPedidoPago;

                decimal diferenca = pedidoEntity.Single().Total - total_pago - pagamentoPedidoEntity.ValorPago;

                if (diferenca >= 0)
                {
                    await _repository.PagamentoPedidoBaseRepository.InsertAsync(pagamentoPedidoEntity);
                }
                else
                {
                    pagamentoPedidoEntity.AlterarValorPago(pagamentoPedidoEntity.ValorPago + diferenca);
                    await _repository.PagamentoPedidoBaseRepository.InsertAsync(pagamentoPedidoEntity);

                    pedidoEntity.Single().FinalizarPedido();

                    var pedidoAtualizado = await _repository.PedidoBaseRepository.Update(pedidoEntity.Single());
                }

                if (!await _repository.CommitAsync())
                    return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest("Não foi possível inserir registro.");

                var pagamentos = await _repository.PagamentoPedidoRespoitory.GetPagamentosByIdPedido(pedidoEntity.Single().Id, filtro);

                var dtos = DtoMapper.ParcePagamentoPedidoDto(pagamentos);

                var result = new PagamentoPedidoDtoInserirResult(pedidoEntity.Single().Id, pedidoEntity.Single().Finalizado, dtos.ToList(), diferenca < 0 ? diferenca * -1 : 0, pedidoEntity.Single().Total);

                return RequestResult<PagamentoPedidoDtoInserirResult>.Ok(result);
            }
            catch (Exception ex)
            {

                return RequestResult<PagamentoPedidoDtoInserirResult>.BadRequest(ex.Message);
            }
        }
    }
}

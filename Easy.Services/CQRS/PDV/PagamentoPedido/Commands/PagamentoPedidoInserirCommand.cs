using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.PagamentoPedido.Commands;

public class PagamentoPedidoInserirCommand : BaseCommands
{
    public Guid FormaPagamentoId { get; set; }
    public Guid PedidoId { get; set; }
    public decimal ValorPago { get; set; }

    public class PagamentoPedidoInserirCommandHandler(IUnitOfWork _repository) : IRequestHandler<PagamentoPedidoInserirCommand, RequestResult>
    {
        public async Task<RequestResult> Handle(PagamentoPedidoInserirCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var pagamentoPedidoEntity = PagamentoPedidoEntity.Inserir(request.FormaPagamentoId, request.PedidoId, request.ValorPago, filtro);
                if (!pagamentoPedidoEntity.Validada)
                    return new RequestResult().EntidadeInvalida();
                await _repository.PagamentoPedidoBaseRepository.InsertAsync(pagamentoPedidoEntity);

                if (!await _repository.CommitAsync())
                    return new RequestResult().BadRequest("Não foi possível inserir pagamento.");

                return new RequestResult().Ok("Pagamento inserido.");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

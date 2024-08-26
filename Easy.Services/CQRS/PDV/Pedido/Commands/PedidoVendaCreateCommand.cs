using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Pedido;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Commands;

public class PedidoVendaCreateCommand : BaseCommands<PedidoDto>
{
    public required PedidoDtoCreate PedidoDtoCreate { get; set; }

    public class PedidoVendaCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<PedidoVendaCreateCommand, RequestResult<PedidoDto>>
    {
        public async Task<RequestResult<PedidoDto>> Handle(PedidoVendaCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pedidoVendaEntity = PedidoEntity.GerarPedidoVenda(request.PedidoDtoCreate.NumeroPedido, request.PedidoDtoCreate.PontoVendaId, request.PedidoDtoCreate.CategoriaPrecoId, filtro);

                if (!pedidoVendaEntity.Validada)
                    return RequestResult<PedidoDto>.BadRequest();

                await _repository.PedidoBaseRepository.InsertAsync(pedidoVendaEntity);

                if (!await _repository.CommitAsync())
                    return RequestResult<PedidoDto>.BadRequest();                

                return RequestResult<PedidoDto>.Ok(mensagem: "Pedido gerado com sucesso.");
            }
            catch (Exception ex)
            {

                return RequestResult<PedidoDto>.BadRequest(ex.Message);
            }
        }
    }
}


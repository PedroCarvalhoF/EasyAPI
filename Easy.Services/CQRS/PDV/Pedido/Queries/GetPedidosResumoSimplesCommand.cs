using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Pedido;
using Easy.Services.DTOs.Pedido.Request;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pedido.Queries
{
    public class GetPedidosResumoSimplesCommand : BaseCommands<PedidoDtoResumoSimples>
    {
        public required RequestPedidoResumoSimples RequestPedidoResumoSimples { get; set; }

        public class GetPedidosResumoSimplesCommandHandler(IUnitOfWork _repository) : IRequestHandler<GetPedidosResumoSimplesCommand, RequestResult<PedidoDtoResumoSimples>>
        {
            public async Task<RequestResult<PedidoDtoResumoSimples>> Handle(GetPedidosResumoSimplesCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var filtro = request.GetFiltro();

                    var filtroPedido = new PedidoEntityFilter
                    {
                        PontoVendaEntityId = request.RequestPedidoResumoSimples.PdvId
                    };

                    var pedidosEntities = await _repository.PedidoRepository.SelectAsync(filtroPedido, filtro);

                    var pedidosValidos = pedidosEntities.Where(pedido => pedido.Cancelado == false && pedido.Finalizado == true);

                    var pedidosCancelados = pedidosEntities.Where(pedido => pedido.Cancelado == true && pedido.Finalizado == true);

                    var pedidosPendentes = pedidosEntities.Where(pedido => pedido.Cancelado == false && pedido.Finalizado == false);


                    var pedidosResumo = new PedidoDtoResumoSimples(
                        request.RequestPedidoResumoSimples.PdvId,
                        DtoMapper.ParcePedidoDto(pedidosValidos).ToList(),
                        DtoMapper.ParcePedidoDto(pedidosCancelados).ToList(),
                        DtoMapper.ParcePedidoDto(pedidosPendentes).ToList());

                    return RequestResult<PedidoDtoResumoSimples>.Ok(pedidosResumo);

                }
                catch (Exception ex)
                {

                    return RequestResult<PedidoDtoResumoSimples>.BadRequest(ex.Message);
                }
            }
        }
    }
}

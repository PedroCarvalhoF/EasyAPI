using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PDV.Dashboard;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.Pdv.Queries;

public class GetPontoVendaDashboardQueryPdvFilter : BaseCommands<GetPontoVendaDashboardQueryPdvFilterResult>
{
    public required PontoVendaQueryFilter PontoVendaQueryFilter { get; set; }
    public class GetPontoVendaDashboardQueryPdvFilterHandler(IUnitOfWork _repository) : IRequestHandler<GetPontoVendaDashboardQueryPdvFilter, RequestResult<GetPontoVendaDashboardQueryPdvFilterResult>>
    {
        public async Task<RequestResult<GetPontoVendaDashboardQueryPdvFilterResult>>
            Handle(GetPontoVendaDashboardQueryPdvFilter request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var pdvEntities = await _repository.PontoVendaRepository.SelectAsync(request.PontoVendaQueryFilter, filtro);
                var pdvDtos = DtoMapper.ParcePontoVendaDto(pdvEntities);

                var pedidos_entities_validos = pdvEntities.SelectMany(pdv_pedidos => pdv_pedidos.Pedidos ?? Enumerable.Empty<PedidoEntity>()).Where(pedido => pedido.Finalizado && pedido.Cancelado == false);

                var pedido_validos_dtos = DtoMapper.ParcePedidoDto(pedidos_entities_validos);


                //pagamentos do pedido
                var pagamentos_pedidos_validos_dtos = DtoMapper.ParcePagamentoPedidoDto(pedidos_entities_validos.SelectMany(pedido_pagamentos => pedido_pagamentos.Pagamentos ?? Enumerable.Empty<PagamentoPedidoEntity>()).Where(pgt => pgt.Habilitado == true));


                //itens do pedido
                var itens_pedidos_entities_validos = pedidos_entities_validos.SelectMany(itens => itens.ItensPedido ?? Enumerable.Empty<ItemPedidoEntity>()).Where(item => item.Cancelado == false);
                var itens_pedido_dtos = DtoMapper.ParceItemPedidoDto(itens_pedidos_entities_validos);


                var dto = DtoMapper.ParcePontoVendaDashboard(pdvDtos, pedido_validos_dtos, pagamentos_pedidos_validos_dtos, itens_pedido_dtos, pdvEntities.Sum(pedido => pedido.QuantidadePedidosCancelados));

                return new RequestResult<GetPontoVendaDashboardQueryPdvFilterResult>().ResultOk(dto);
            }
            catch (Exception ex)
            {

                return new RequestResult<GetPontoVendaDashboardQueryPdvFilterResult>().Erro(ex);
            }
        }
    }
}

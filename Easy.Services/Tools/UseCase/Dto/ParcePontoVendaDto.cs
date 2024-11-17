using Easy.Domain.Entities.PDV.PDV;
using Easy.Services.DTOs.ItemPedido;
using Easy.Services.DTOs.PagamentoPedido;
using Easy.Services.DTOs.PDV;
using Easy.Services.DTOs.PDV.Dashboard;
using Easy.Services.DTOs.Pedido;
using static Easy.Services.DTOs.PDV.Dashboard.GetPontoVendaDashboardQueryPdvFilterResult;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static PontoVendaDto ParcePontoVendaDto(PontoVendaEntity pdv)
        {
            return new PontoVendaDto(
                pdv.Id,
                pdv.UsuarioGerentePdvId,
                pdv.UsuarioGerentePdv!.UserPdv!.Nome!,
                pdv.UsuarioPdvId,
                pdv.UsuarioPdv!.UserPdv!.Nome!,
                pdv.Aberto,
                pdv.PeriodoPdvId,
                pdv.PeriodoPdv!.DescricaoPeriodo!,
                pdv.CreateAt,

                pdv.QtdPedidos,
                pdv.QuantidadePedidosValidos,
                pdv.QuantidadePedidosCancelados,

                pdv.SomaValorTotalPedidos,
                pdv.SomaValorTotalPedidosValidos,
                pdv.SomaValorTotalPedidosCancelados,

                pdv.TicketMedio,
                pdv.SomaDescontoPedidosValidos);
        }

        public static IEnumerable<PontoVendaDto> ParcePontoVendaDto(IEnumerable<PontoVendaEntity> pdvEntities)
        {
            foreach (var pdv in pdvEntities)
            {
                yield return ParcePontoVendaDto(pdv);
            }
        }

        public static GetPontoVendaDashboardQueryPdvFilterResult ParcePontoVendaDashboard(IEnumerable<PontoVendaDto> pdvsDtos, IEnumerable<PedidoDto> pedidosValidos, IEnumerable<PagamentoPedidoDto> pagamentosDto, IEnumerable<ItemPedidoDto> itensPedidosDtos)
        {
            var dash = new GetPontoVendaDashboardQueryPdvFilterResult();

            dash.CreatAtDashboard = $"Dashboard gerado: {DateTime.Now.ToString()}";

            dash.Faturamento = pdvsDtos.Sum(pdvs => pdvs.SomaValorTotalPedidosValidos);
            dash.TC = pdvsDtos.Sum(pdvs => pdvs.QuantidadePedidosValidos);
            try
            {
                dash.TM = dash.Faturamento / dash.TC;
            }
            catch (DivideByZeroException)
            {

                dash.TM = 0;
            }

            dash.byCategoriaPrecos = pedidosValidos
                    .Where(p => !string.IsNullOrEmpty(p.CategoriaPreco)) // Ignorar categorias nulas ou vazias
                    .GroupBy(p => p.CategoriaPreco)
                    .Select(g => new byCategoriaPreco
                    {
                        CategoriaPreco = g.Key,
                        Quantidade = g.Count(),
                        Total = g.Sum(p => p.Total ?? 0),
                        Media = g.Sum(p => p.Total ?? 0) / g.Count()
                    })
                    .ToList();


            dash.byPagamentos = pagamentosDto
            .Where(p => !string.IsNullOrEmpty(p.FormaPagamento)) // Ignorar pagamentos com FormaPagamento nula ou vazia
            .GroupBy(p => p.FormaPagamento)
            .Select(g => new byFormaPagamento
            {
                FormaPagamento = g.Key,
                Quantidade = g.Count(),
                TotalValorPago = g.Sum(p => p.ValorPago)
            })
            .ToList();


            // Agrupando por NomeProduto
            dash.byItensPedidos = itensPedidosDtos
                 .Where(item => !item.Cancelado) // Excluir itens cancelados
                 .GroupBy(item => item.NomeProduto)
                 .Select(group => new byItem
                 {
                     NomeProduto = group.Key,
                     Quantidade = group.Sum(item => item.Quantidade),
                     Total = group.Sum(item => item.TotalItem)
                 })
                 .OrderBy(group => group.NomeProduto).ToList();


            return dash;
        }


    }
}

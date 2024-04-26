using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Enuns;
using static Domain.Dtos.PedidoDtos.DashPontoVendaDtosV2;

namespace Service.Services.PontoVendaService
{
    public class PontoVendaDetalhado
    {
        internal static IEnumerable<PedidoDto> FiltrarPedidosPontoVenda(IEnumerable<PontoVendaDto> pdvs, SituacaoPedidoEnum situacaoPedido, bool consultarPedidosOkCancelados)
        {
            if (consultarPedidosOkCancelados)
                return pdvs.SelectMany(pedido => pedido.PedidoEntity);
            else
                if (situacaoPedido == SituacaoPedidoEnum.Finalizado)
            {
                return pdvs.SelectMany(pedido => pedido.PedidoEntity?.Where(p => p.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Finalizado)));
            }
            else
                return pdvs.SelectMany(pedido => pedido.PedidoEntity?.Where(p => p.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Cancelado)));
        }

        internal static decimal? TotalFaturado(IEnumerable<PedidoDto> all_validos)
        => all_validos.Sum(p => p.ValorPedido);

        internal static int TotalPedido(IEnumerable<PedidoDto> pedidos)
        => pedidos.Count();


        internal static List<ProdutosAgrupados> ProdutosRegistrados(List<PedidoDto> pedidos)
        {
            IEnumerable<Domain.Dtos.ItemPedido.ItemPedidoDto> itens_pedidos = pedidos.SelectMany(item => item.ItemPedidoEntity);
            IOrderedEnumerable<ProdutosAgrupados> agrupamento = itens_pedidos
                .GroupBy(item => new { item.ProdutoEntity.Id, item.ProdutoEntity.NomeProduto })
                .Select(grupo => new ProdutosAgrupados
                {
                    IdProdutoAgrupado = grupo.Key.Id, // Incluindo o ID do produto
                    NomeProdutoAgrupado = grupo.Key.NomeProduto,
                    QtdSomaAgrupado = grupo.Sum(item => item.Quatidade)
                }).OrderByDescending(grupo => grupo.QtdSomaAgrupado);

            return agrupamento.ToList();
        }

        internal static List<PagamentosInformadosAgrupados> PagamentosRegistrados(List<PedidoDto> pedidos)
        {
            IEnumerable<Domain.Dtos.PagamentoPedidoDtos.PagamentoPedidoDto> pagamentos = pedidos.SelectMany(pedido => pedido.PagamentoPedidoEntity);
            IOrderedEnumerable<PagamentosInformadosAgrupados> agrupamento = pagamentos
                .GroupBy(pgt => new { pgt.FormaPagamentoEntity.Id, pgt.FormaPagamentoEntity.DescricaoFormaPg })
                .Select(grupo => new PagamentosInformadosAgrupados
                {
                    IdFpgtInformadoAgrupado = grupo.Key.Id, // Incluindo o ID do produto
                    FpgtInformadoAgrupado = grupo.Key.DescricaoFormaPg,
                    QtdInformadaAgrupado = grupo.Count(),
                    QtdSomaFpgtAgrupado = grupo.Sum(item => item.ValorPago)
                }).OrderByDescending(grupo => grupo.QtdSomaFpgtAgrupado);

            return agrupamento.ToList();
        }
    }
}

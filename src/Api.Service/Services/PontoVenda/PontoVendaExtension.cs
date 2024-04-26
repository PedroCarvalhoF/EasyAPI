using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.PontoVenda;
using Domain.Dtos.PontoVendaDtos;
using Domain.Enuns;
using static Domain.Dtos.PontoVendaDtos.PontoVendaResumoDetalhadoDto;
using static Service.Services.PontoVendaService.PontoVendaResumoDiaDto;

namespace Service.Services.PontoVendaService
{
    public static class PontoVendaExtension
    {
        public static PontoVendaResumoDetalhadoDto GetResumoDetalhadoPdV(PontoVendaDto pdv)
        {

            PontoVendaResumoDetalhadoDto detalhes = new PontoVendaResumoDetalhadoDto();

            IEnumerable<PedidoDto>? pedidos_validos = pdv.PedidoEntity?.Where(pedidos => pedidos.SituacaoPedidoEnum == Domain.Enuns.SituacaoPedidoEnum.Finalizado);


            detalhes.QTD_PEDIDOS = QTD_PEDIDOS(pedidos_validos.ToList());
            detalhes.TOTAL_ITENS = TOTAL_ITENS(pedidos_validos.ToList());
            detalhes.TOTAL_DESCONTO = TOTAL_DESCONTO(pedidos_validos.ToList());
            detalhes.TOTAL_VALOR_PEDIDO = TOTAL_VALOR_PEDIDO(pedidos_validos.ToList());
            detalhes.TM = detalhes.TOTAL_VALOR_PEDIDO / detalhes.QTD_PEDIDOS;
            detalhes.GROUP_PRODUTOS_TEM = ITENS_PEDIDOS(pedidos_validos.ToList());
            detalhes.GROUP_PAGAMENTO_INFORMADO = PAGAMENTOS_INFORMADOS_PEDIDOS(pedidos_validos.ToList());

            IEnumerable<PedidoDto>? pedidos_cancelados = pdv.PedidoEntity?.Where(pedidos => pedidos.SituacaoPedidoEnum == Domain.Enuns.SituacaoPedidoEnum.Finalizado);




            return detalhes;
        }

        public static List<PontoVendaResumoDiaDto> GetResumoDia(List<PontoVendaDto> pdvs)
        {
            List<PontoVendaResumoDiaDto> pontoVendaResumoDias = new List<PontoVendaResumoDiaDto>();

            IEnumerable<PedidoDto> pedidos = pdvs.SelectMany(p => p?.PedidoEntity?.Where(p => p.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Finalizado)));

            PontoVendaResumoDiaDto dash = new PontoVendaResumoDiaDto();




            IEnumerable<PontoVendaResumoDiaDto> pedidos_group_by = pedidos
        .GroupBy(pedido => pedido.CreateAt.Date)
                    .Select(grupo => new
                    {
                        Data = grupo.Key,
                        Faturamento = grupo.Sum(p => p.ValorPedido),
                        TC = grupo.Count(p => p.ValorPedido > 0),
                        Pagamentos = grupo
                            .SelectMany(ped => ped.PagamentoPedidoEntity)
                            .GroupBy(pagamento => pagamento.FormaPagamentoEntity.DescricaoFormaPg) // Grupo por tipo de pagamento, ajuste conforme necessário
                            .Select(grupoPagamento => new
                            {
                                Tipo = grupoPagamento.Key,
                                ValorTotal = grupoPagamento.Sum(pag => pag.ValorPago)
                            })
                    })
                    .Select(resumo => new PontoVendaResumoDiaDto
                    {
                        Data = resumo.Data.ToString("d"),
                        Faturamento = resumo.Faturamento,
                        TC = resumo.TC,
                        TM = (decimal)resumo.Faturamento / resumo.TC,
                        Pagamentos = resumo.Pagamentos.Select(pag => new PagamentosVendaResumoDia
                        {
                            Descricao = pag.Tipo,
                            Valor = pag.ValorTotal
                        })
                    });


            return pedidos_group_by.ToList();
        }

        
        public static int QTD_PEDIDOS(List<PedidoDto> pedidos)
        {
            return pedidos.Count();
        }
        private static decimal TOTAL_ITENS(List<PedidoDto> pedidos)
        {
            decimal total_itens_vendidos = pedidos.Sum(pedido => pedido.TotalItensPedido ?? 0);

            return total_itens_vendidos;
        }
        private static decimal TOTAL_DESCONTO(List<PedidoDto> pedidos)
        {
            decimal total_desconto = pedidos.Sum(pedido => pedido.ValorDesconto ?? 0);

            return total_desconto;
        }
        private static decimal TOTAL_VALOR_PEDIDO(List<PedidoDto> pedidos)
        {
            decimal TOTAL_VALOR_PEDIDO = pedidos.Sum(pedido => pedido.ValorPedido ?? 0);

            return TOTAL_VALOR_PEDIDO;
        }
        private static List<ProdutoItensGroupBy> ITENS_PEDIDOS(List<PedidoDto> pedidos)
        {
            IEnumerable<Domain.Dtos.ItemPedido.ItemPedidoDto> itens = pedidos.SelectMany(item => item.ItemPedidoEntity);

            List<Domain.Dtos.ItemPedido.ItemPedidoDto> itens_registrados = itens.Where(item => item.SituacaoItemPedidoEnum.Equals(SituacaoItemPedidoEnum.ItemRegistrado)).ToList();

            List<ProdutoItensGroupBy> resultado = itens_registrados
           .GroupBy(item => item.ProdutoEntity.NomeProduto)
           .Select(grupo => new ProdutoItensGroupBy
           {
               Produto = grupo.Key,
               Quantidade = grupo.Sum(item => item.Quatidade)
           }).OrderByDescending(p => p.Quantidade).ToList();


            return resultado;
        }
        private static List<PagamentoItensGroupBy> PAGAMENTOS_INFORMADOS_PEDIDOS(List<PedidoDto> pedidos)
        {
            IEnumerable<Domain.Dtos.PagamentoPedidoDtos.PagamentoPedidoDto> pagamentos = pedidos.SelectMany(pgt => pgt.PagamentoPedidoEntity);

            List<PagamentoItensGroupBy> resultado = pagamentos
           .GroupBy(item => item.FormaPagamentoEntity.DescricaoFormaPg)
           .Select(grupo => new PagamentoItensGroupBy
           {
               FormaPagamento = grupo.Key,
               SomaValorPago = grupo.Sum(item => item.ValorPago)
           }).OrderBy(p => p.FormaPagamento).ToList();


            return resultado;
        }

    }
}

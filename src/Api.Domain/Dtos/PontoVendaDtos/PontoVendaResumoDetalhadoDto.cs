namespace Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaResumoDetalhadoDto
    {
        public int QTD_PEDIDOS { get; set; }
        public decimal TOTAL_ITENS { get; set; }
        public decimal TOTAL_DESCONTO { get; set; }
        public decimal TOTAL_VALOR_PEDIDO { get; set; }
        public decimal TM { get; set; }
        public List<ProdutoItensGroupBy> GROUP_PRODUTOS_TEM { get; set; }
        public List<PagamentoItensGroupBy> GROUP_PAGAMENTO_INFORMADO { get; set; }

        public class ProdutoItensGroupBy
        {
            public string Produto { get; set; }
            public decimal Quantidade { get; set; }
        }

        public class PagamentoItensGroupBy
        {
            public string FormaPagamento { get; set; }
            public decimal SomaValorPago { get; set; }
        }

    }
}

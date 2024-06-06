
namespace Domain.Dtos.PontoVenda.Dashboards
{
    public class DashPontoVendaResult
    {
        public Guid IdPdv { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public string? Periodo { get; set; }
        public string? Situacao { get; set; }
        public string? ResponsavelAbertura { get; set; }
        public string? ResponsavelOperador { get; set; }
        public decimal Faturamento { get; set; }
        public int QuantidadePedidos { get; set; }
        public decimal TicktMedido { get; set; }
        public IEnumerable<ResumoPagamento>? ResumoPagamento { get; set; }
        public IEnumerable<ResumoProdutos>? ResumoProdutos { get; set; }
        public IEnumerable<CategoriaPrecoGroupBy>? ResumoVendasByCategoriaPrecoGroupBy { get; set; }
        public IEnumerable<ProdutosByCategoriaGroupBy>? ResumoProdutosQtdPrecoTotalByAvulso { get; set; }
        public IEnumerable<ProdutosByCategoriaGroupBy>? ProdutosByCategoriaPrecoGroupBy { get; set; }
        public IEnumerable<PagamentoByCategoriaPreco>? PagamentoByCategoriaPrecoGroupBy { get; set; }

    }


    public class ResumoPagamento
    {
        public string? FormaPagamento { get; set; }
        public decimal ValorPagoInformado { get; set; }
    }

    public class ResumoProdutos
    {
        public string? NomeProduto { get; set; }
        public decimal TotalProdutos { get; set; }
    }
    public class PagamentoByCategoriaPreco
    {
        public string? CategoriaPreco { get; set; }
        public string? FormaPagamento { get; set; }
        public int QtdPagamentoGroup { get; set; }
        public decimal SomaValorPago { get; set; }

    }
    public class CategoriaPrecoGroupBy
    {
        public string? Categoria { get; set; }
        public int QuantidadePedido { get; set; }
        public decimal SomaValorPedido { get; set; }
        public decimal TicketMedio { get; set; }
    }

    public class ProdutosByCategoriaGroupBy
    {
        public string? CategoriaPreco { get; set; }
        public string? NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public decimal QuantidadeTotal { get; set; }
        public decimal SomaTotal { get; set; }
    }


}

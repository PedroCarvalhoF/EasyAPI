
namespace Domain.Dtos.PontoVenda.Dashboards
{
    public class DashPontoVendaResult
    {
        public DateTime DataAbertura { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public string? Periodo { get; set; }
        public string? Situacao { get; set; }
        public string? ResponsavelAbertura { get; set; }
        public string? ResponsavelOperador { get; set; }
        public decimal Faturamento { get; set; }
        public int QuantidadePedidos { get; set; }
        public decimal TicktMedido { get; set; }
        public IEnumerable<CategoriaPrecoGroupBy>? ResumoVendasByCategoriaPrecoGroupBy { get; set; }
        public IEnumerable<ProdutosByCategoriaGroupBy>? ProdutosByCategoriaPrecoGroupBy { get; set; }
        public IEnumerable<PagamentoByCategoriaPreco>? PagamentoByCategoriaPrecoGroupBy { get; set; }
    }

    public class CategoriaPrecoGroupBy
    {
        public string? Categoria { get; set; }
        public decimal SomaValorPedido { get; set; }
        public int QuantidadePedido { get; set; }
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
    public class PagamentoByCategoriaPreco
    {
        public string CategoriaPreco { get; internal set; }
        public string FormaPagamento { get; internal set; }
        public decimal SomaValorPago { get; internal set; }
    }

}

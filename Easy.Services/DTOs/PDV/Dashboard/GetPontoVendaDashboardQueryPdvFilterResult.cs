namespace Easy.Services.DTOs.PDV.Dashboard;

public class GetPontoVendaDashboardQueryPdvFilterResult
{
    public string? CreatAtDashboard { get; internal set; }
    public decimal Faturamento { get; internal set; }
    public decimal TC { get; internal set; }
    public decimal TM { get; internal set; }

    public List<byCategoriaPreco>? byCategoriaPrecos { get; internal set; } = new List<byCategoriaPreco>();
    public List<byFormaPagamento>? byPagamentos { get; internal set; } = new List<byFormaPagamento>();
    public List<byItem>? byItensPedidos { get; internal set; } = new List<byItem>();


    //RESUMO FATURAMENTO VALIDO POR CATEGORIA DE PREÇO
    public class byCategoriaPreco
    {
        public string? CategoriaPreco { get; internal set; }
        public int Quantidade { get; internal set; }
        public decimal Total { get; internal set; }
        public decimal Media { get; internal set; }
    }

    public class byFormaPagamento
    {
        public string? FormaPagamento { get; internal set; }
        public int Quantidade { get; internal set; }
        public decimal TotalValorPago { get; internal set; }
    }

    public class byItem
    {
        public string? NomeProduto { get; internal set; }       
        public decimal Quantidade { get; internal set; }
        public decimal Total { get; internal set; }
    }
}

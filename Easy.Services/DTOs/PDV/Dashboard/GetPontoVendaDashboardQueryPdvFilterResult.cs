namespace Easy.Services.DTOs.PDV.Dashboard;

public class GetPontoVendaDashboardQueryPdvFilterResult
{
    public string? Mensagem { get; internal set; } = "Nenhum resultado encontrado.";
    public decimal Faturamento { get; internal set; } = 0;
    public decimal TC { get; internal set; } = 0;
    public decimal TM { get; internal set; } = 0;
    public decimal TC_cancelados { get; internal set; } = 0;

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

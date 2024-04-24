using Api.Domain.Dtos.PedidoDtos;

namespace Domain.Dtos.PedidoDtos
{
    public class DashPontoVendaDtosV2
    {
        public List<PedidoDto>? all_pedidos { get; set; }
        public List<PedidoDto>? all_validos { get; set; }
        public List<PedidoDto>? all_pedidos_cancelados { get; set; }
        public int total_pedido { get; set; }
        public int total_pedido_validos { get; set; }
        public int total_pedidos_cancelados { get; set; }
        public decimal? faturamento { get; set; }
        public int TC { get; set; }
        public decimal? TM { get; set; }

        public void CalculaTM(decimal? fat, int? tc)
        {
            TM = fat / tc;
        }

        public List<ProdutosAgrupados> ListaProdutosAgrupados = new List<ProdutosAgrupados>();
        public class ProdutosAgrupados
        {
            public Guid IdProdutoAgrupado { get; set; }
            public string? NomeProdutoAgrupado { get; set; }
            public decimal QtdSomaAgrupado { get; set; }
        }


        public List<PagamentosInformadosAgrupados> ListaFpgtsInformados = new List<PagamentosInformadosAgrupados>();
        public class PagamentosInformadosAgrupados
        {
            public Guid IdFpgtInformadoAgrupado { get; set; }
            public string? FpgtInformadoAgrupado { get; set; }
            public decimal QtdSomaFpgtAgrupado { get; set; }
            public int QtdInformadaAgrupado { get; set; }
        }

    }
}

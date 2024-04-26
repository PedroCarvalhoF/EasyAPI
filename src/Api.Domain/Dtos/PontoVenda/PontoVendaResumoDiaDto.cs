using Api.Domain.Dtos.PedidoDtos;

namespace Service.Services.PontoVendaService
{
    public class PontoVendaResumoDiaDto
    {
        public string Data { get; set; }
        public decimal? Faturamento { get; set; }
        public int TC { get; set; }
        public decimal TM { get; set; }
        public object Pagamentos { get; set; }

        public IEnumerable<PedidoDto>? pedidosValidos { get; set; }

        public class PagamentosVendaResumoDia
        {
            public string Descricao { get; set; }
            public decimal Valor { get; set; }
        }
    }
}

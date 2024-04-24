using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.FormaPagamentoDtos;

namespace Domain.Dtos.PagamentoPedidoDtos
{
    public class PagamentoPedidoDto
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }

        public PedidoDto? PedidoEntity { get; set; }
        public FormaPagamentoDto? FormaPagamentoEntity { get; set; }
        public decimal ValorPago { get; set; }
    }
}

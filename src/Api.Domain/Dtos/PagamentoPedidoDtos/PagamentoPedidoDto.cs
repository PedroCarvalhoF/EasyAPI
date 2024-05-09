using Api.Domain.Dtos;
using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.FormaPagamentoDtos;

namespace Domain.Dtos.PagamentoPedidoDtos
{
    public class PagamentoPedidoDto : BaseDto
    {
               public PedidoDto? PedidoEntity { get; set; }
        public FormaPagamentoDto? FormaPagamentoEntity { get; set; }
        public decimal ValorPago { get; set; }
    }
}

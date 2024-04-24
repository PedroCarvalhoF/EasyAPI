using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.FormaPagamentoDtos;

namespace Domain.Models.PagamentoPedidoModels
{
    public class PagamentoPedidoModels
    {
        public Guid? PedidoEntityId { get; set; }
        public PedidoDto? PedidoEntity { get; set; }
        public Guid? FormaPagamentoEntityId { get; set; }
        public FormaPagamentoDto? FormaPagamentoEntity { get; set; }
        public decimal ValorPago { get; set; }
    }
}

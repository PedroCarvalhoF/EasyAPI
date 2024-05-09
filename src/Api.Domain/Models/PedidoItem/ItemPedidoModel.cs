using Api.Domain.Models;

namespace Domain.Models.ItemPedidoModels
{
    public class ItemPedidoModel : ModelBase
    {
        public Guid ProdutoEntityId { get; set; }
        public decimal Quatidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string? ObservacaoItem { get; set; }
        public Guid PerfilUsuarioEntityId { get; set; }
        public Guid PedidoEntityId { get; set; }

        public void Calular()
        {
            this.SubTotal = this.Quatidade * this.Preco;
            this.Total = this.SubTotal - this.Desconto;
        }

        public void CancelarItemPedido()
        {
            this.Habilitado = false;
        }

        public void GerarItemPedido()
        {
            this.Habilitado = true;
            Calular();
        }
    }
}

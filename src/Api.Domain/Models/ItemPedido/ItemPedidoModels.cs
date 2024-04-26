using Api.Domain.Models;
using Domain.Enuns;
using Domain.ExceptionsPersonalizadas;

namespace Domain.Models.ItemPedidoModels
{
    public class ItemPedidoModels : BaseModel
    {
        public ItemPedidoModels(Guid produtoEntityId, decimal quatidade, decimal preco, decimal desconto, string? observacaoItem, Guid pedidoEntityId, Guid usuarioRestroId)
        {
            ProdutoEntityId = produtoEntityId;

            Quatidade = quatidade;
            Preco = preco;
            Desconto = desconto;

            ObservacaoItem = observacaoItem?.ToLower();

            SituacaoItemPedidoEnum = SituacaoItemPedidoEnum.ItemRegistrado;
            PedidoEntityId = pedidoEntityId;
            UsuarioRestroId = usuarioRestroId;



            CalcularTotalItem();
        }

        public SituacaoItemPedidoEnum VerificarSituacao()
        {
            return SituacaoItemPedidoEnum;
        }
        public void CalcularSubTotal()
        {
            this.SubTtotal = this.Quatidade * this.Preco;
        }

        public void CalcularTotalItem()
        {
            CalcularSubTotal();

            if (this.Desconto == 0)
                this.TotalItem = SubTtotal;
            else
                if (this.Desconto > this.SubTtotal)
            {
                throw new ModelsExceptions("Não é possível aplicar um desconto maior que valor do item.");
            }

            this.TotalItem = SubTtotal - this.Desconto;
        }

        public void CancelarItem()
        {
            if (SituacaoItemPedidoEnum.Equals(SituacaoItemPedidoEnum.ItemCancelado))
                throw new ModelsExceptions("Item já está cancelado");

            SituacaoItemPedidoEnum = SituacaoItemPedidoEnum.ItemCancelado;
        }

        public Guid ProdutoEntityId { get; private set; }

        public decimal Quatidade { get; private set; }
        public decimal Preco { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal SubTtotal { get; private set; }
        public decimal TotalItem { get; private set; }
        public string? ObservacaoItem { get; private set; }
        public SituacaoItemPedidoEnum SituacaoItemPedidoEnum { get; private set; }
        public Guid PedidoEntityId { get; private set; }
        public Guid UsuarioRestroId { get; private set; }
    }
}

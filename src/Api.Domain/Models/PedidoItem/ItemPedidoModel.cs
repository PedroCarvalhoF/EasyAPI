﻿using Api.Domain.Models;

namespace Domain.Models.ItemPedidoModels
{
    public class ItemPedidoModel : BaseModel
    {
        public ItemPedidoModel(Guid produtoEntityId, decimal quatidade, decimal preco, decimal desconto, string? observacaoItem, Guid usuarioPontoVendaEntityId, Guid pedidoEntityId)
        {

            if (quatidade <= 0)
            {
                throw new Exception("Quantidade não pode ser menor que zero");
            }
            if (preco < 0)
            {
                throw new Exception("Preço não pode ser menor que zero");
            }

            if (desconto < 0)
            {
                throw new Exception("Desconto não pode ser menor que zero");
            }

            ProdutoEntityId = produtoEntityId;
            Quatidade = quatidade;
            Preco = preco;
            Desconto = desconto;
            ObservacaoItem = observacaoItem;
            UsuarioPontoVendaEntityId = usuarioPontoVendaEntityId;
            PedidoEntityId = pedidoEntityId;
        }

        public Guid ProdutoEntityId { get; private set; }
        public decimal Quatidade { get; private set; }
        public decimal Preco { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal Total { get; private set; }
        public string? ObservacaoItem { get; private set; }
        public Guid UsuarioPontoVendaEntityId { get; private set; }
        public Guid PedidoEntityId { get; private set; }
        private void Calular()
        {
            this.SubTotal = this.Quatidade * this.Preco;
            this.Total = this.SubTotal - this.Desconto;
        }
        public void CancelarItemPedido()
        {
            if (!this.Habilitado)
                throw new Exception("Item do pedido ja está cancelado");

            this.Habilitado = false;
        }
        public void GerarItemPedido()
        {
            this.Habilitado = true;
            Calular();
        }
    }
}

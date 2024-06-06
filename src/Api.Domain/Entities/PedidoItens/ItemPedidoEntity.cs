using Api.Domain.Entities;
using Api.Domain.Entities.Pedido;
using Domain.Entities.PontoVendaUser;
using Domain.Entities.Produto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ItensPedido
{
    public class ItemPedidoEntity : BaseEntity
    {

        [Required(ErrorMessage = "Informe o id do produto")]
        public Guid ProdutoEntityId { get; set; }
        public ProdutoEntity? ProdutoEntity { get; set; }



        [Required(ErrorMessage = "Informe o id do produto")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quatidade { get; set; }



        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "Informe o subTotal ")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }



        [Required(ErrorMessage = "Informe o desconto")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Desconto { get; set; }



        [Required(ErrorMessage = "Informe ")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }




        [MaxLength(200)]
        public string? ObservacaoItem { get; set; }



        [Required(ErrorMessage = "Informe id usuario registro")]
        public Guid UsuarioPontoVendaEntityId { get; set; }
        public UsuarioPontoVendaEntity? UsuarioPontoVendaEntity { get; set; }
        //###################################################

        [Required(ErrorMessage = "Informe codigo do pedido")]
        public Guid PedidoEntityId { get; set; }
        public PedidoEntity? PedidoEntity { get; set; }

        //###################################################

    }
}

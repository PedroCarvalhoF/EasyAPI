﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.ItemPedido
{
    public class ItemPedidoDtoCreate
    {
        [Required]
        public Guid ProdutoEntityId { get; set; }

        [Required]
        public decimal Quatidade { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public decimal Desconto { get; set; }


        [MaxLength(200)]
        public string? ObservacaoItem { get; set; }

        [Required]
        public Guid PedidoEntityId { get; set; }
      
        public Guid UsuarioPontoVendaEntityId { get; set; }

    }
}

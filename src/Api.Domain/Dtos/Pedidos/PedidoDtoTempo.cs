using Api.Domain.Dtos.PontoVendaDtos;
using Domain.Dtos.PedidoSituacao;
using Domain.Dtos.PerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Pedidos
{
    public class PedidoDtoTempo
    {
        public string? NumeroPedido { get; set; }
       
        public decimal? ValorPedido { get; set; }
    
        public SituacaoPedidoDto? SituacaoPedidoEntity { get; set; }

    }
}

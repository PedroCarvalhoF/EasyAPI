using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using Domain.Entities.PagamentoPedido;
using Domain.Entities.PedidoSituacao;
using Domain.Entities.UsuarioSistema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities.Pedido
{
    public class PedidoEntity : BaseEntity
    {
        [DisplayName("Número do Pedido")]
        [Required(ErrorMessage = "Informe o {0}")]
        [MaxLength(100, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? NumeroPedido { get; set; }
        //############################################################

        [DisplayName("Valor de Desconto")]
        [Required(ErrorMessage = "Informe o {0}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorDesconto { get; set; } = 0;
        //############################################################

        [DisplayName("Valor de Desconto")]
        [Required(ErrorMessage = "Informe o {0}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorPedido { get; set; } = 0;
        //############################################################

        [DisplayName("Observações")]
        [MaxLength(100, ErrorMessage = "Não pode passar de {0} caracteres")]
        public string? Observacoes { get; set; } = string.Empty;
        //############################################################

        [DisplayName("Id Situação")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid SituacaoPedidoEntityId { get; set; }
        public SituacaoPedidoEntity? SituacaoPedidoEntity { get; set; }
        //############################################################

        [DisplayName("Id PDV")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid? PontoVendaEntityId { get; set; }
        public PontoVendaEntity? PontoVendaEntity { get; set; }
        //############################################################

        [DisplayName("Id Categoria Preço")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid? CategoriaPrecoEntityId { get; set; }
        public CategoriaPrecoEntity? CategoriaPrecoEntity { get; set; }
        //############################################################

        [DisplayName("Id PDV")]
        [Required(ErrorMessage = "Informe o {0}")]
        public Guid UserCreatePedidoId { get; set; }
        public PerfilUsuarioEntity? UserCreatePedido { get; set; }
        //############################################################

        public IEnumerable<ItemPedidoEntity>? ItensPedidoEntities { get; set; }
        public IEnumerable<PagamentoPedidoEntity>? PagamentoPedidoEntities { get; set; }

    }
}

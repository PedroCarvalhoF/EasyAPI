using Api.Domain.Entities.Pedido;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.UsuarioSistema;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities.PontoVenda
{
    public class PontoVendaEntity : BaseEntity
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Perfil Abertura")]
        public Guid IdPerfilAbriuPDV { get; set; }
        public PerfilUsuarioEntity? PerfilUsuarioEntityAbrilPDV { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Perfil Utilizar o PDV")]
        public Guid IdPerfilUtilizarPDV { get; set; }
        public PerfilUsuarioEntity? PerfilUsuarioEntityUtilizarPDV { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Periodo do PDV")]
        public Guid PeriodoPontoVendaEntityId { get; set; }
        [Required]
        public PeriodoPontoVendaEntity? PeriodoPontoVendaEntity { get; set; }


        /// <summary>
        /// AbertoFechado
        /// Idenficar se o Ponto de Venda ja foi encerrado.
        /// TRUE- DIPONIVEL para lançar novos pedidos,alterações em geral
        /// FALSE- INDISPONIVEL - apenas para consultas.
        /// </summary>
        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Situação do PDV")]
        public bool AbertoFechado { get; set; }

        public IEnumerable<PedidoEntity>? PedidoEntities { get; set; }

    }
}

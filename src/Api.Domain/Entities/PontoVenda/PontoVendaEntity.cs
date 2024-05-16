using Api.Domain.Entities.Pedido;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.PontoVendaUser;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities.PontoVenda
{
    public class PontoVendaEntity : BaseEntity
    {        
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Perfil Abertura")]
        public Guid UserPdvCreateId { get; set; }
        public UsuarioPontoVendaEntity? UserPdvCreate { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Perfil Utilizar o PDV")]
        public Guid UserPdvUsingId { get; set; }
        public UsuarioPontoVendaEntity? UserPdvUsing { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Id Periodo do PDV")]
        public Guid PeriodoPontoVendaEntityId { get; set; }
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

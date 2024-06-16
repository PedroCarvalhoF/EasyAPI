using Api.Domain.Entities.Pedido;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.Entities.PontoVendaUser;

namespace Api.Domain.Entities.PontoVenda
{
    public class PontoVendaEntity : BaseEntity
    {       
        public Guid UserPdvCreateId { get; set; }
        public UsuarioPontoVendaEntity? UserPdvCreate { get; set; }        
        public Guid UserPdvUsingId { get; set; }
        public UsuarioPontoVendaEntity? UserPdvUsing { get; set; }
      
        public Guid PeriodoPontoVendaEntityId { get; set; }
        public PeriodoPontoVendaEntity? PeriodoPontoVendaEntity { get; set; }  
        public bool AbertoFechado { get; set; }
        public IEnumerable<PedidoEntity>? PedidoEntities { get; set; }

    }
}

using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.Entities.PontoVendaUser;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDto : BaseDto
    {        
        public UsuarioPontoVendaEntity? UserPdvCreate { get; set; }
        public UsuarioPontoVendaEntity? UserPdvUsing { get; set; }
        public PeriodoPontoVendaDto? PeriodoPontoVendaEntity { get; set; }
        public bool AbertoFechado { get; set; }        
        public IEnumerable<PedidoDto>? PedidoEntities { get; set; }
    }
}

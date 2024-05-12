using Api.Domain.Dtos.PedidoDtos;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;
using Domain.Identity.UserIdentity;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public User? UserPdvCreate { get; set; }
        public User? UserPdvUsing { get; set; }
        public PeriodoPontoVendaDto? PeriodoPontoVendaEntity { get; set; }
        public bool AbertoFechado { get; set; }

        public IEnumerable<PedidoDto>? PedidoEntities { get; set; }
    }
}

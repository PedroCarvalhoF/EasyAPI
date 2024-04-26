using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Enuns;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDtoCreateResult : BaseDto
    {
        public Guid UserIdCreatePdv { get; set; }
        public Guid UserIdResponsavel { get; set; }
        public PeriodoPontoVendaEnum PeriodoPontoVendaEnum { get; set; }
        public bool AbertoFechado { get; set; }
        public IEnumerable<PedidoDto>? PedidoEntity { get; set; }
        public DateTime? DataAlteracaoEncerrado { get; set; }
    }
}

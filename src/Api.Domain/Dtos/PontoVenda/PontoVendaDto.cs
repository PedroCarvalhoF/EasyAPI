using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Enuns;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDto //: BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid UserIdCreatePdv { get; set; }
        public Guid UserIdResponsavel { get; set; }
        public PeriodoPontoVendaEnum PeriodoPontoVendaEnum { get; set; }
        public bool AbertoFechado { get; set; }
        public IEnumerable<PedidoDto>? PedidoEntity { get; set; }
        public DateTime? DataAlteracaoEncerrado { get; set; }

        public override string ToString()
        => $"ID: {Id} - Data Abertura: {CreateAt.ToString("G")}";
    }
}

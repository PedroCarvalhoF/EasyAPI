using Domain.Dtos.PerfilUsuario;
using Domain.Dtos.PontoVendaPeriodoVendaDtos;

namespace Api.Domain.Dtos.PontoVendaDtos
{
    public class PontoVendaDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Habilitado { get; set; }

        public PerfilUsuarioDto? PerfilUsuarioEntityAbrilPDV { get; set; }
        public PerfilUsuarioDto? PerfilUsuarioEntityUtilizarPDV { get; set; }
        public PeriodoPontoVendaDto? PeriodoPontoVendaEntity { get; set; }
        public bool AbertoFechado { get; set; }
    }
}

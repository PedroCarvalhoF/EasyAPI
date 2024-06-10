using Api.Domain.Dtos;

namespace Domain.Dtos.Pessoas.DadosBancarios
{
    public class DadosBancariosDto : BaseDto
    {
        public string? BancoSalario { get; set; }
        public string? Agencia { get; set; }
        public string? ContaComDigito { get; set; }
    }
}

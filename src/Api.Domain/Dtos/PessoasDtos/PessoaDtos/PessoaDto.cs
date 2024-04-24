using Api.Domain.Dtos.PessoasDtos.PessoaTipoDtos;

namespace Domain.Dtos.PessoasDtos.PessoaDtos
{
    public class PessoaDto
    {
        public string? PrimeiroNome { get; set; }
        public string? SegundoNome { get; set; }
        public string? Sexo { get; set; }
        public string? RgIE { get; set; }
        public string? CpfCnpj { get; set; }
        public DateTime DataNascimentoFundacao { get; set; }
        public PessoaTipoDto? PessoaTipoEntity { get; set; }
    }
}

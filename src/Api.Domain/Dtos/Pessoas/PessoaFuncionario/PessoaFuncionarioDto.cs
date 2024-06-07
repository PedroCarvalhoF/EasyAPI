using Domain.Entities.Pessoa.Pessoas;
using Domain.Enuns.Pessoas;

namespace Domain.Dtos.Pessoas.PessoaFuncionario
{
    public class PessoaFuncionarioDto
    {
        public bool FuncionarioAtivo { get; set; }
        public Guid? PessoaEntityId { get; set; }
        public PessoaEntity? PessoaEntity { get; set; }
        public string? NomePai { get; set; }
        public string? NomeMae { get; set; }
        public PessoaRacaCorEnum PessoaRacaCorEnum { get; set; }
        public PessoaGeneroEnum PessoaGeneroEnum { get; set; }
        public PessoaTiposanguineoEnum PessoaTiposanguineoEnum { get; set; }
        public bool Deficiente { get; set; }
        public string? TipoDeficiencia { get; set; }
        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }
        public string? CTPS { get; set; }
        public string? SerieCTPS { get; set; }
        public string? NumeroTitulo { get; set; }
        public string? ZonaTitulo { get; set; }
        public string? SecaoTitulo { get; set; }
        public PessoaGrauInstrucaoEnum? PessoaGrauInstrucaoEnum { get; set; }
        public string? NumeroPis { get; set; }
        public PessoaEstadoCivilEnum? PessoaEstadoCivilEnum { get; set; }
        public bool ContaBancoOk { get; set; }
        public string? BancoSalario { get; set; }
        public string? AgenciaBancoSalario { get; set; }
        public string? ContaComDigitoBancoSalario { get; set; }
        public PessoaFuncionarioFuncaoEnum PessoaFuncionarioFuncaoEnum { get; set; }
    }
}

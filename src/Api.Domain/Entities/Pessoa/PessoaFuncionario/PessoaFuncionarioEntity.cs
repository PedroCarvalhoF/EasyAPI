using Api.Domain.Entities;
using Domain.Entities.Pessoa.Pessoas;
using Domain.Enuns.Pessoas;

namespace Domain.Entities.Pessoa.PessoaFuncionario
{
    public class PessoaFuncionarioEntity : BaseEntity
    {
        //pessoa
        public Guid? PessoaEntityId { get; set; }
        public PessoaEntity? PessoaEntity { get; set; }

        //detalhes da pessoa
        public PessoaRacaCorEnum? PessoaRacaCorEnum { get; set; }
        public PessoaGeneroEnum? PessoaGeneroEnum { get; set; }
        public PessoaTiposanguineoEnum? PessoaTiposanguineoEnum { get; set; }
        public PessoaEstadoCivilEnum? PessoaEstadoCivilEnum { get; set; }
        public bool Deficiente { get; set; }
        public string? TipoDeficiencia { get; set; }
        public string? Naturalidade { get; set; }
        public string? Nacionalidade { get; set; }

        //filiacao da pessoa
        public string? NomePai { get; set; }
        public string? NomeMae { get; set; }

        //dados carteira da pessoa
        public string? NumeroCTPS { get; set; }
        public string? SerieCTPS { get; set; }
        public string? NumeroPis { get; set; }

        //titulo da pessoa
        public string? NumeroTitulo { get; set; }
        public string? ZonaTitulo { get; set; }
        public string? SecaoTitulo { get; set; }

        //dados bancario
        public bool ContaBancoOk { get; set; }
        public string? BancoSalario { get; set; }
        public string? AgenciaBancoSalario { get; set; }
        public string? ContaComDigitoBancoSalario { get; set; }



        public bool FuncionarioAtivo { get; set; }

        public PessoaFuncionarioFuncaoEnum PessoaFuncionarioFuncaoEnum { get; set; }


        //Filiacao
        public Guid FiliacaoFuncionarioEntityId { get; set; }
        public FiliacaoFuncionarioEntity? FiliacaoFuncionarioEntity { get; set; }

        //Funcao
        public Guid CargoFuncionarioEntityId { get; set; }
        public CargoFuncionarioEntity? CargoFuncionarioEntity { get; set; }
    }
}

using Api.Domain.Entities;

namespace Domain.Entities.Pessoa.PessoaFuncionario
{
    public class FiliacaoFuncionarioEntity : BaseEntity
    {
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public PessoaFuncionarioEntity? PessoaFuncionarioEntity { get; set; }
    }
}

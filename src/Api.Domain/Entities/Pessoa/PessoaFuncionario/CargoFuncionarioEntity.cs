using Api.Domain.Entities;

namespace Domain.Entities.Pessoa.PessoaFuncionario
{
    public class CargoFuncionarioEntity : BaseEntity
    {
        public string? DescricaoCargo { get; set; }
        public PessoaFuncionarioEntity? PessoaFuncionarioEntity { get; set; }
    }
}

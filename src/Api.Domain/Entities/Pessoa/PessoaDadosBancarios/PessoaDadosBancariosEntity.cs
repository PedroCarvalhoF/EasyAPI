using Domain.Entities.Pessoa.DadosBancarios;

namespace Domain.Entities.Pessoa.PessoaDadosBancarios
{
    public class PessoaDadosBancariosEntity
    {
        public Guid PessoaEntityId { get; set; }
        public PessoaEntity? PessoaEntity { get; set; }

        public Guid DadosBancariosEntityId { get; set; }
        public DadosBancariosEntity? DadosBancariosEntity { get; set; }
    }
}

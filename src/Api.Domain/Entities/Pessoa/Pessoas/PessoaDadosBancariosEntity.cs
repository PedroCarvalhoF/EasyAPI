namespace Domain.Entities.Pessoa.Pessoas
{
    public class PessoaDadosBancariosEntity
    {
        public Guid PessoaEntityId { get; set; }
        public PessoaEntity PessoaEntity { get; set; }

        public Guid DadosBancariosEntityId { get; set; }
        public DadosBancariosEntity DadosBancariosEntity { get; set; }
    }
}

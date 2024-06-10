using Domain.Enuns.Pessoas;

namespace Domain.Dtos.Pessoas.Contato
{
    public class ContatoDto
    {
        public Guid Id { get; set; }
        public TipoContatoEnum? TipoContatoEnum { get; set; }
        public string? Numero { get; set; }
    }
}

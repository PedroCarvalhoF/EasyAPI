using Api.Domain.Models;
using Domain.Enuns.Pessoas;

namespace Domain.Models.Pessoas.Contato
{
    public class ContatoModel : BaseModel
    {
        public TipoContatoEnum? TipoContatoEnum { get; set; }
        public string? Numero { get; set; }
    }
}

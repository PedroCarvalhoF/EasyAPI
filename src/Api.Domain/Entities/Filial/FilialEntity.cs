using Api.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Filial
{
    public class FilialEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? NomeFilial { get; private set; }

        public FilialEntity(string? nomeFilial)
        {
            NomeFilial = nomeFilial;
        }
    }
}

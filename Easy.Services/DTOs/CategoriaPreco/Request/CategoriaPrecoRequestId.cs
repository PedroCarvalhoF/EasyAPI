using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.CategoriaPreco.Request
{
    public class CategoriaPrecoRequestId
    {
        [Required]
        public Guid IdCategoriaPreco { get; private set; }

        public CategoriaPrecoRequestId(Guid idCategoriaPreco)
        {
            IdCategoriaPreco = idCategoriaPreco;
        }
    }
}

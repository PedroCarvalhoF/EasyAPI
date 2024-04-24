using Api.Domain.Dtos.PedidoDtos;

namespace Api.Domain.Dtos.CategoriaPrecoDtos
{
    public class CategoriaPrecoDto  /*: BaseDto*/
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string? DescricaoCategoria { get; set; }

        public bool Habilitado { get; set; }

        public IEnumerable<PedidoDto>? PedidoEntity { get; set; }

    }
}
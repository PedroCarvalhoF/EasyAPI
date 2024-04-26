using Api.Domain.Dtos.PedidoDtos;

namespace Api.Domain.Dtos.CategoriaPrecoDtos
{
    public class CategoriaPrecoDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string? DescricaoCategoria { get; set; }
        public bool Habilitado { get; set; }       

    }
}
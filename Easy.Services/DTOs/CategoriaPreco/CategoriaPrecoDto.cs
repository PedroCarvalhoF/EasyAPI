namespace Easy.Services.DTOs.CategoriaPreco;

public class CategoriaPrecoDto
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public bool Habilitado { get; set; }
    public int Codigo { get; set; }
    public string DescricaoCategoriaPreco { get; set; }

}

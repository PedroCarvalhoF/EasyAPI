namespace Easy.Services.DTOs.CategoriaProduto;

public class CategoriaProdutoDtoView
{
    public Guid Id { get; set; }
    public bool Habilitado { get; set; }
    public string? Codigo { get; set; }
    public string? DescricaoCategoria { get; set; }
}

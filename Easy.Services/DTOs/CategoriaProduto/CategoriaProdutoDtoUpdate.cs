namespace Easy.Services.DTOs.CategoriaProduto;

public class CategoriaProdutoDtoUpdate
{
    public Guid Id { get; set; }
    public bool Habilitado { get; set; }
    public string DescricaoCategoria { get; set; }
    public CategoriaProdutoDtoUpdate(Guid id, bool habilitado, string descricaoCategoria)
    {
        Id = id;
        Habilitado = habilitado;
        DescricaoCategoria = descricaoCategoria;
    }
}

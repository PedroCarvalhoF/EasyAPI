namespace Easy.Services.DTOs.CategoriaProduto;

public class CategoriaProdutoDto
{
    public Guid Id { get; private set; }
    public bool Habilitado { get; private set; }
    public string DescricaoCategoria { get; private set; }
    public CategoriaProdutoDto(Guid id, bool habilitado, string descricaoCategoria)
    {
        Id = id;
        Habilitado = habilitado;
        DescricaoCategoria = descricaoCategoria;
    }
}

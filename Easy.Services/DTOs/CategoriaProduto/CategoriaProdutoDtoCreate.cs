namespace Easy.Services.DTOs.CategoriaProduto;

public class CategoriaProdutoDtoCreate
{
    public string DescricaoCategoria { get; private set; }
    public CategoriaProdutoDtoCreate(string descricaoCategoria)
    {
        DescricaoCategoria = descricaoCategoria;
    }
}

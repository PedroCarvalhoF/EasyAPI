namespace Easy.Services.DTOs.CategoriaPreco;

public class CategoriaPrecoDtoCreate
{
    public CategoriaPrecoDtoCreate(int codigo, string descricaoCategoriaPreco)
    {
        Codigo = codigo;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
    }

    public int Codigo { get; set; }
    public string DescricaoCategoriaPreco { get; set; }
}

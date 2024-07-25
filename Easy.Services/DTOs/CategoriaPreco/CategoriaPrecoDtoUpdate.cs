namespace Easy.Services.DTOs.CategoriaPreco;

public class CategoriaPrecoDtoUpdate
{
    public Guid Id { get; private set; }
    public bool Habilitado { get; private set; }
    public int Codigo { get; private set; }
    public string DescricaoCategoriaPreco { get; private set; }
    public CategoriaPrecoDtoUpdate(Guid id, int codigo, string descricaoCategoriaPreco, bool habilitado)
    {
        Id = id;
        Codigo = codigo;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
        Habilitado = habilitado;
    }
}

namespace Easy.Services.DTOs.CategoriaPreco;

public class CategoriaPrecoDto
{
    public Guid Id { get; private set; }
    public bool Habilitado { get; private set; }
    public int Codigo { get; private set; }
    public string DescricaoCategoriaPreco { get; private set; }
    public CategoriaPrecoDto(Guid id, bool habilitado, int codigo, string descricaoCategoriaPreco)
    {
        Id = id;
        Habilitado = habilitado;
        Codigo = codigo;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
    }
}

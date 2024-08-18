using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.CategoriaPreco;

public class CategoriaPrecoDtoCreate
{
    [Required]
    public int Codigo { get; set; }
    [Required]
    public string DescricaoCategoriaPreco { get; set; }
    public CategoriaPrecoDtoCreate(int codigo, string descricaoCategoriaPreco)
    {
        Codigo = codigo;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
    }   
}

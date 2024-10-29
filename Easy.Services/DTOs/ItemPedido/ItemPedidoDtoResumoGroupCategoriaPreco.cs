namespace Easy.Services.DTOs.ItemPedido;

public class ItemPedidoDtoResumoGroupCategoriaPreco
{
    public string CategoriaPreco { get; private set; }
    public string NomeProduto { get; private set; }
    public decimal Preco { get; private set; }
    public decimal QuantidadeTotal { get; private set; }
    public decimal SomaTotal { get; private set; }
    public ItemPedidoDtoResumoGroupCategoriaPreco(string categoriaPreco, string nomeProduto, decimal preco, decimal quantidadeTotal, decimal somaTotal)
    {
        CategoriaPreco = categoriaPreco;
        NomeProduto = nomeProduto;
        Preco = preco;
        QuantidadeTotal = quantidadeTotal;
        SomaTotal = somaTotal;
    }  
}

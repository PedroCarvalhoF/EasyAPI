using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.Produto;

namespace Easy.Domain.Entities.PDV.PrecoProduto;

public class PrecoProdutoEntity : BaseEntity
{
    public Guid ProdutoEntityId { get; private set; }
    public Guid CategoriaPrecoEntityId { get; set; }
    public decimal Preco { get; private set; }
    public ProdutoEntity? Produto { get; private set; }
    public CategoriaPrecoEntity? CategoriaPreco { get; private set; }
    public bool Validada => Validar();

    private bool Validar()
    {
        if (ProdutoEntityId == Guid.Empty) return false;
        if (CategoriaPrecoEntityId == Guid.Empty) return false;
        if (Preco == 0 || Preco < 0) return false;

        return true;
    }

    public PrecoProdutoEntity() { }
    PrecoProdutoEntity(Guid produtoEntityId, Guid categoriaPrecoEntityId, decimal preco, FiltroBase filtro) : base(filtro)
    {
        ProdutoEntityId = produtoEntityId;
        CategoriaPrecoEntityId = categoriaPrecoEntityId;
        Preco = preco;
    }

    PrecoProdutoEntity(Guid id, bool habilitado, Guid produtoEntityId, Guid categoriaPrecoEntityId, decimal preco, FiltroBase filtro)
        : base(id, habilitado, filtro)
    {
        ProdutoEntityId = produtoEntityId;
        CategoriaPrecoEntityId = categoriaPrecoEntityId;
        Preco = preco;
        UpdateAt = DateTime.Now;
    }

    public static PrecoProdutoEntity Create(Guid produtoEntityId, Guid categoriaPrecoEntityId, decimal preco, FiltroBase filtro)
        => new PrecoProdutoEntity(produtoEntityId, categoriaPrecoEntityId, preco, filtro);

    public static PrecoProdutoEntity Update(Guid id, bool habilitado, Guid produtoEntityId, Guid categoriaPrecoEntityId, decimal preco, FiltroBase filtro)
        => new PrecoProdutoEntity(id, habilitado, produtoEntityId, categoriaPrecoEntityId, preco, filtro);

   
}

namespace Easy.Domain.Entities.Produto.CategoriaProduto;

public class CategoriaProdutoEntityFilter
{
    public Guid? CategoriaProdutoId { get; set; } = null;
    public string? DescricaoCategoriasProdutosEquals { get; set; } = null;
    public string? DescricaoCategoriasProdutosContains { get; set; } = null;

    public static IQueryable<CategoriaProdutoEntity> QueryableEntity(IQueryable<CategoriaProdutoEntity> query, CategoriaProdutoEntityFilter filtro)
    {
        if (filtro.CategoriaProdutoId != null && filtro.CategoriaProdutoId != Guid.Empty)
            return query = query.Where(categora => categora.Id.Equals(filtro.CategoriaProdutoId));

        if (!string.IsNullOrWhiteSpace(filtro.DescricaoCategoriasProdutosEquals))
            return query = query.Where(categoria => categoria.DescricaoCategoria.Equals(filtro.DescricaoCategoriasProdutosEquals));
        else
            if (!string.IsNullOrEmpty(filtro.DescricaoCategoriasProdutosContains))
            return query = query.Where(categoria => categoria.DescricaoCategoria.ToLower().Contains(filtro.DescricaoCategoriasProdutosContains.ToLower()));

        return query;
    }
}

public class CategoriaProdutoEntityFilterDapper
{
    public bool? GetAll { get; set; }
    public Guid? CategoriaProdutoId { get; set; }
    public string? DescricaoCategoriasProdutosEquals { get; set; } = null;
    public string? DescricaoCategoriasProdutosContains { get; set; } = null;
}

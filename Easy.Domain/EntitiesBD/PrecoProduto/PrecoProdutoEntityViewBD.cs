namespace Easy.Domain.EntitiesBD.PrecoProduto;

public class PrecoProdutoEntityViewBD
{
    //select
    //`preco_prod`.`Id` as `PrecoProdutoId`,
    //`preco_prod`.`Habilitado` as `PrecoHabilitado`,
    //`preco_prod`.`ProdutoEntityId` as `ProdutoId`,
    //`prod`.`NomeProduto` as `NomeProduto`,
    //`preco_prod`.`Preco` as `Preco`,
    //`cat_preco`.`Id` as `CategoriaPrecoId`,
    //`cat_preco`.`DescricaoCategoriaPreco` as `DescricaoCategoriaPreco`
    public Guid PrecoProdutoId { get; private set; }
    public bool PrecoHabilitado { get; private set; }
    public Guid ProdutoId { get; private set; }
    public string NomeProduto { get; private set; }
    public decimal Preco { get; private set; }
    public Guid CategoriaPrecoId { get; private set; }
    public string DescricaoCategoriaPreco { get; private set; }
    public PrecoProdutoEntityViewBD(Guid precoProdutoId, bool precoHabilitado, Guid produtoId, string nomeProduto, decimal preco, Guid categoriaPrecoId, string descricaoCategoriaPreco, Guid UserMasterClienteIdentityId, Guid UserId)
    {
        PrecoProdutoId = precoProdutoId;
        PrecoHabilitado = precoHabilitado;
        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        Preco = preco;
        CategoriaPrecoId = categoriaPrecoId;
        DescricaoCategoriaPreco = descricaoCategoriaPreco;
    }
}

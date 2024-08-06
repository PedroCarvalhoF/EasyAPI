namespace Easy.InfrastructureData.Dapper.Mapping;

public static class ContextMappingDapper
{
    public static string GetCategoriaProdutoTable()
        => "desenvolvimento.categoriasprodutos";
    public static string GetProdutoTable()
       => "desenvolvimento.produtos";

    public static string GetUserMasterUserTable()
        => "desenvolvimento.usermastercliente";
    public static string GetUserTable()
        => "desenvolvimento.aspnetusers";
}
namespace Easy.InfrastructureData.Dapper.Mapping;

public static class ContextMappingDapper
{
    private const string nome_banco_dados = "desenvolvimento";

    //PRODUTOS
    public static string GetProdutosNomeTabela()
     => $"{nome_banco_dados}.produtos";
    public static string GetProdutosNomeView()
      => $"{nome_banco_dados}.vw_produtos";

    //CATEGORIA PRODUTOS
    public static string GetTableNameCagoriasProdutos()
        => $"{nome_banco_dados}.categoriasprodutos";


    //USER MASTER
    public static string GetUserMasterUserTable()
        => $"{nome_banco_dados}.usermastercliente";
    public static string GetUserTable()
        => $"{nome_banco_dados}.aspnetusers";
}
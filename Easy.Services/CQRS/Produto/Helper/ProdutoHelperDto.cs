using Easy.Domain.Enuns;

namespace Easy.Services.CQRS.Produto.Helper
{
    public static class ProdutoHelperDto
    {
        public static string GetMedida(MedidaProdutoEnum medida)
        {
            switch (medida)
            {
                case MedidaProdutoEnum.Unidade:
                    return "Unidade";
                case MedidaProdutoEnum.Peso:
                    return "Peso";
                default:
                    return "Unidade";
            }
        }

        public static string GetTipo(ProdutoTipoEnum produtoTipo)
        {
            switch (produtoTipo)
            {
                case ProdutoTipoEnum.Venda:
                    return "Venda";
                case ProdutoTipoEnum.MateriaPrima:
                    return "Matéria Prima";
                case ProdutoTipoEnum.Brinde:
                    return "Brinde";
                default:
                    return "Venda";
            }
        }
    }
}

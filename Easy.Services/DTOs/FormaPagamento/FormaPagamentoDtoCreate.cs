namespace Easy.Services.DTOs.FormaPagamento;

public class FormaPagamentoDtoCreate
{
    public string DescricaFormaPagamento { get; private set; }
    public int Codigo { get; private set; }
    public FormaPagamentoDtoCreate(string descricaFormaPagamento, int codigo)
    {
        DescricaFormaPagamento = descricaFormaPagamento;
        Codigo = codigo;
    }    
}

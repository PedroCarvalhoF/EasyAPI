namespace Easy.Services.DTOs.FormaPagamento;

public class FormaPagamentoDtoUpdate
{
    public Guid Id { get; private set; }
    public string DescricaFormaPagamento { get; private set; }
    public int Codigo { get; private set; }
    public bool Habilitado { get; private set; }
    public FormaPagamentoDtoUpdate(Guid id, string descricaFormaPagamento, int codigo, bool habilitado = false)
    {
        Id = id;
        DescricaFormaPagamento = descricaFormaPagamento;
        Codigo = codigo;
        Habilitado = habilitado;
    }
}

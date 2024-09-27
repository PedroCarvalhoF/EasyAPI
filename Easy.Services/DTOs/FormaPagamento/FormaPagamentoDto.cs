namespace Easy.Services.DTOs.FormaPagamento;

public class FormaPagamentoDto
{
    public Guid Id { get; private set; }
    public string DescricaFormaPagamento { get; private set; }
    public int Codigo { get; private set; }
    public bool Habilitado { get; private set; }
    public FormaPagamentoDto(Guid id, string descricaFormaPagamento, int codigo, bool habilitado = false)
    {
        Id = id;
        DescricaFormaPagamento = descricaFormaPagamento;
        Codigo = codigo;
        Habilitado = habilitado;
    }
}

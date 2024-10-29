namespace Easy.Services.DTOs.PDV;

public class PontoVendaDtoEncerrarResult
{
    public bool Finalizado { get; private set; } = false;
    public string Mensagem { get; private set; } = "Não foi possível realizar operação.";
    public DateTime DataHora => DateTime.Now;
    PontoVendaDtoEncerrarResult(bool finalizado)
    {
        Finalizado = finalizado;        
        Mensagem = finalizado ? "Ponto de Venda Finalizado" : "Não foi possível realizar operação.";
    }
    public static PontoVendaDtoEncerrarResult PontoVendaEncerrado(bool finalizado)
         => new PontoVendaDtoEncerrarResult(finalizado);
}

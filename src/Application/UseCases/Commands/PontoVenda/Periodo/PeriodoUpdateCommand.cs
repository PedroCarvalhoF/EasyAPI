namespace Application.UseCases.Commands.PontoVenda.Periodo
{
    public class PeriodoUpdateCommand : ICommand
    {
        public Guid Id { get; set; }
        public string? DescricaoPeriodo { get; set; }
    }
}

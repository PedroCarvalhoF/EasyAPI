namespace Api.Domain.Models.PontoVendaModels
{
    public class PontoVendaModel : ModelBase
    {
        public Guid IdPerfilAbriuPDV { get; set; }
        public Guid IdPerfilUtilizarPDV { get; set; }
        public Guid PeriodoPontoVendaEntityId { get; set; }
        public bool AbertoFechado { get; set; }

        public void AbrirPDV()
        {
            AbertoFechado = true;
        }

        public void FinalizarPDV()
        {
            AbertoFechado = false;
        }
    }
}

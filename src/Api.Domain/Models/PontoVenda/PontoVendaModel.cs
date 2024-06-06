using Api.Domain.Models.PedidoModels;

namespace Api.Domain.Models.PontoVendaModels
{
    public class PontoVendaModel : BaseModel
    {

        public Guid UserPdvCreateId { get; set; }
        public Guid UserPdvUsingId { get; set; }
        public Guid PeriodoPontoVendaEntityId { get; set; }
        public bool AbertoFechado { get; set; }
        public int QtdPedidos { get; set; }

        public void Calcular(IEnumerable<PedidoModel> pedidos)
        {
            this.QtdPedidos = pedidos.Count();
        }
        public void AbrirPDV()
        {
            AbertoFechado = true;
        }

        public void FinalizarPDV()
        {
            if (!AbertoFechado)
                throw new Exception("PDV já está fechado");

            AbertoFechado = false;
        }
        public IEnumerable<PedidoModel>? Pedidos { get; set; }
    }
}

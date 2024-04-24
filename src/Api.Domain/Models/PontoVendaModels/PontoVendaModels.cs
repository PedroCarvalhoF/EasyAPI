using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Enuns;
using Domain.Enuns;
using Domain.ExceptionsPersonalizadas;

namespace Api.Domain.Models.PontoVendaModels
{
    public class PontoVendaModels
    {
        public Guid Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public Guid UserIdCreatePdv { get; set; }
        public Guid UserIdResponsavel { get; set; }
        public PeriodoPontoVendaEnum PeriodoPontoVendaEnum { get; set; }
        public bool AbertoFechado { get; set; }
        public IEnumerable<PedidoDto>? PedidoEntity { get; set; }
        public DateTime? DataAlteracaoEncerrado { get; set; }

        public void GerarPontoVendaModels()
        {
            this.Id = Guid.NewGuid();
            this.CreateAt = DateTime.Now;
            this.AbertoFechado = true;
            this.PedidoEntity = new List<PedidoDto>();
            this.DataAlteracaoEncerrado = null;
        }

        public void EncerrarPontoVendaModels()
        {
            int? pedidoAberto = PedidoEntity?.Count(pedidos => pedidos.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Aberto));

            if (pedidoAberto > 0)
                throw new ModelsExceptions("Não foi possível encerrar ponto de venda.Finalize ou cancele todos os pedidos em andamento para concluir a operação");

            this.AbertoFechado = false;
            this.DataAlteracaoEncerrado = DateTime.Now;
        }


    }
}

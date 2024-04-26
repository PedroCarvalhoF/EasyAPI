using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Entities.PontoVenda;
using Domain.Entities.ItensPedido;
using Domain.Enuns;
using Domain.ExceptionsPersonalizadas;
namespace Api.Domain.Models.PedidoModels
{
    public class PedidoModels
    {
        public PedidoModels(string? numeroPedido, string? observacoes, Guid userIdCreatePedido, Guid pontoVendaEntityId, Guid categoriaPrecoEntityID)
        {
            GerarPedidoModel(numeroPedido, observacoes, userIdCreatePedido, pontoVendaEntityId, categoriaPrecoEntityID);
        }
        private void GerarPedidoModel(string? numeroPedido, string? observacoes, Guid userIdCreatePedido, Guid pontoVendaEntityId, Guid categoriaPrecoEntityID)
        {

            if (numeroPedido == null)
                numeroPedido = "Avulso";
            if (string.IsNullOrEmpty(numeroPedido))
                numeroPedido = "Avulso";

            if (observacoes == null)
                observacoes = "sem observações";
            if (string.IsNullOrEmpty(observacoes))
                observacoes = "sem observações";



            NumeroPedido = numeroPedido;
            TotalItensPedido = 0;
            ValorDesconto = 0;
            ValorPedido = 0;
            SituacaoPedidoEnum = SituacaoPedidoEnum.Aberto;
            Observacoes = observacoes;
            UserIdCreatePedido = userIdCreatePedido;
            DataUltimaAtualizacao = DateTime.Now;
            PontoVendaEntityId = pontoVendaEntityId;
            CategoriaPrecoEntityId = categoriaPrecoEntityID;
            this.ItemPedidoEntity = new List<ItemPedidoEntity>();



        }

        public void EncerrarPedidoModels()
        {
            if (this.ValorPedido < 0)
                throw new ModelsExceptions("Não é possivel fornecer um desconto maior que o valor do pedido");

            CalcularValorPedido();



            this.DataUltimaAtualizacao = DateTime.Now;
            this.SituacaoPedidoEnum = SituacaoPedidoEnum.Finalizado;
        }

        public void CalcularValorPedido()
        {
            if (this.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Cancelado))
            {
                throw new ModelsExceptions("Não é possível reaizar operação: Pedido cancelado.");
            }

            if (this.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Finalizado))
            {
                throw new ModelsExceptions("Não é possível reaizar operação: Pedido Finalizado.");
            }

            IEnumerable<ItemPedidoEntity> itensPedido = from item in ItemPedidoEntity
                                                        where item.SituacaoItemPedidoEnum.Equals(SituacaoItemPedidoEnum.ItemRegistrado)
                                                        select item;

            this.TotalItensPedido = itensPedido.Count();

            this.ValorDesconto = itensPedido.Sum(item => item.Desconto);

            this.ValorPedido = itensPedido.Sum(item => item.TotalItem) - this.ValorDesconto;
            this.DataUltimaAtualizacao = DateTime.Now;
        }

        public void CancelarPedidoModels(string movitoCancelamento)
        {
            if (this.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Cancelado))
            {
                throw new ModelsExceptions("Pedido já está cancelado.");
            }
            if (Observacoes.Equals("sem observações"))
                this.Observacoes = movitoCancelamento;
            else
                this.Observacoes += movitoCancelamento;

            this.SituacaoPedidoEnum = SituacaoPedidoEnum.Cancelado;
            this.DataUltimaAtualizacao = DateTime.Now;
        }

        public void CancelarTodosItensPedido(IEnumerable<ItemPedidoEntity>? itemPedidoEntity)
        {
            foreach (ItemPedidoEntity item in itemPedidoEntity)
            {
                item.SituacaoItemPedidoEnum = SituacaoItemPedidoEnum.ItemCancelado;
            }
            this.ItemPedidoEntity = itemPedidoEntity;
        }

        public Guid Id { get; private set; }
        public DateTime CreateAt { get; private set; }
        public string? NumeroPedido { get; private set; }
        public decimal? TotalItensPedido { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public decimal? ValorPedido { get; private set; }
        public SituacaoPedidoEnum SituacaoPedidoEnum { get; private set; }
        public string? Observacoes { get; private set; }
        public Guid UserIdCreatePedido { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public Guid? PontoVendaEntityId { get; private set; }
        public PontoVendaEntity? PontoVendaEntity { get; private set; }
        public IEnumerable<ItemPedidoEntity>? ItemPedidoEntity { get; set; }
        public Guid CategoriaPrecoEntityId { get; set; }
        public CategoriaPrecoEntity? CategoriaPrecoEntity { get; set; }
    }
}

namespace Api.Domain.Models.PedidoModels
{
    public class PedidoModel : ModelBase
    {
        public Guid SituacaoPedidoEntityId { get; set; }
        public Guid? PontoVendaEntityId { get; set; }
        public Guid? CategoriaPrecoEntityId { get; set; }
        public Guid? UserCreatePedidoId { get; set; }


        private string? _numeroPedido;

        public string NumeroPedido
        {
            get { return _numeroPedido; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _numeroPedido = "avulso";
                }
                else
                {
                    _numeroPedido = value;
                }
            }
        }


        private decimal _valorDesconto;

        public decimal ValorDesconto
        {
            get { return _valorDesconto; }
            set
            {
                _valorDesconto = value < 0 ? 0 : value;
            }
        }

        private decimal _valorPedido;

        public decimal ValorPedido
        {
            get { return _valorPedido; }
            set
            {
                _valorPedido = value < 0 ? 0 : value;
            }
        }

        private string? _observacoes;

        public string? Observacoes
        {
            get { return _observacoes; }
            set
            {
                _observacoes = string.IsNullOrEmpty(value) ? "sem obsevações" : value;
            }
        }

        public void GerarPedido()
        {
            this.Habilitado = true;

            //guid padrao para aberto 
            //nao alterar!!!!
            this.SituacaoPedidoEntityId = Guid.Parse("abc0f0f9-3295-439c-a468-795b071b7f22");

        }

        public void EncerrarPedido()
        {
            this.Habilitado = true;

            //guid padrao para fechado 
            //nao alterar!!!!
            this.SituacaoPedidoEntityId = Guid.Parse("185b07da-7e82-43d1-b61f-912d8b29a34c");
        }

        public void CancelarPedido(string? motivo)
        {
            this.Habilitado = false;

            //guid padrao para cancelado 
            //nao alterar!!!!
            this.SituacaoPedidoEntityId = Guid.Parse("11b17cc5-c8b1-48f9-b9fd-886339441328");
            this.Observacoes = $"Pedido cancelado: {motivo}";
        }
    }
}
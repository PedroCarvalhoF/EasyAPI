using Domain.Entities.FormaPagamento;

namespace Domain.Dtos.PedidoFormaPagamento
{
    public class FormaPagamentoView
    {
        public Guid Id { get; private set; }
        public string? DescricaoFormaPg { get; private set; }

        public FormaPagamentoView(FormaPagamentoEntity entity)
        {
            Id = entity.Id;
            DescricaoFormaPg = entity.DescricaoFormaPg;
        }

        public static List<FormaPagamentoView> FromEntityList(IEnumerable<FormaPagamentoEntity> formas)
        {
            return formas.Select(entity => new FormaPagamentoView(entity)).ToList();
        }
    }

}
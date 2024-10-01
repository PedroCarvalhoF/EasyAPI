namespace Easy.Services.DTOs.PagamentoPedido
{
    public class PagamentoPedidoDtoResumoPdv
    {
        public Guid PdvId { get; private set; }
        public DateTime DataHoraResumoGerado { get; } = DateTime.Now;
        public string? FormaPagamento { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Soma { get; private set; }
        public decimal Media { get; private set; }

        public PagamentoPedidoDtoResumoPdv(Guid pdvId, string? formaPagamento, int quantidade, decimal soma, decimal media)
        {
            PdvId = pdvId;
            FormaPagamento = formaPagamento;
            Quantidade = quantidade;
            Soma = soma;
            Media = media;
        }
        public static PagamentoPedidoDtoResumoPdv CreateResumo(Guid pdvId, string? formaPagamento, int quantidade, decimal soma, decimal media)
            => new PagamentoPedidoDtoResumoPdv(pdvId, formaPagamento, quantidade, soma, media);
    }
}

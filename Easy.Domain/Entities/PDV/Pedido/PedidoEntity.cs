using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Enuns.Pdv.Pedido;
using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.PDV.Pedido;

public class PedidoEntity : BaseEntity
{
    public TipoPedidoEnum? TipoPedido { get; private set; }
    public string? NumeroPedido { get; private set; }
    public decimal? Desconto { get; private set; } // desconto
    public decimal? SubTotal { get; private set; } // soma dos itens válidos do pedido
    public decimal? Total { get; private set; } // soma dos itens - desconto
    public string? Observacoes { get; private set; }
    public bool? Cancelado { get; private set; }
    public bool? Finalizado { get; private set; }
    public Guid? PontoVendaEntityId { get; private set; }
    public virtual PontoVendaEntity? PontoVendaEntity { get; private set; }
    public Guid? CategoriaPrecoId { get; private set; }

    public virtual CategoriaPrecoEntity? CategoriaPreco { get; private set; }
    public virtual ICollection<ItemPedidoEntity>? ItensPedido { get; set; }
    public virtual ICollection<PagamentoPedidoEntity>? Pagamentos { get; private set; }
    public bool Validada => Validar();

    private bool Validar()
    {
        return true;
    }

    #region Construtores
    public PedidoEntity() { }
    PedidoEntity(TipoPedidoEnum tipoPedido, string? numeroPedido, Guid pontoVendaEntityId, Guid categoriaPrecoId, FiltroBase users) : base(users)
    {
        DomainValidation.When((int)tipoPedido > 2 || (int)tipoPedido <= 0, "Tipo do pedido inválido");
        DomainValidation.When(pontoVendaEntityId == Guid.Empty, "Informe o id do ponto de venda");
        DomainValidation.When(categoriaPrecoId == Guid.Empty, "Informe o id da categoria de preço");

        TipoPedido = tipoPedido;

        if (string.IsNullOrEmpty(numeroPedido))
            NumeroPedido = "Avulso";
        else
            NumeroPedido = numeroPedido;

        PontoVendaEntityId = pontoVendaEntityId;
        CategoriaPrecoId = categoriaPrecoId;

        Desconto = 0;
        SubTotal = 0;
        Total = 0;
        Observacoes = string.Empty;
        Cancelado = false;
        Finalizado = false;
    }

    public static PedidoEntity GerarPedidoVenda(string? numeroPedido, Guid pontoVendaEntityId, Guid categoriaPrecoId, FiltroBase users)
    {
        var pedidoVendaEntity = new PedidoEntity(TipoPedidoEnum.Venda, numeroPedido, pontoVendaEntityId, categoriaPrecoId, users);
        return pedidoVendaEntity;
    }

    public static PedidoEntity GerarPedidoOrcamento(string? numeroPedido, Guid pontoVendaEntityId, Guid categoriaPrecoId, FiltroBase users)
    {
        var pedidoVendaEntity = new PedidoEntity(TipoPedidoEnum.Orcamento, numeroPedido, pontoVendaEntityId, categoriaPrecoId, users);
        return pedidoVendaEntity;
    }

    #endregion
    private void CalcularSubTotal()
    {
        var itens_validos = ItensPedido?.Where(item => item.Habilitado == true && item.Cancelado == false).ToList() ?? new List<ItemPedidoEntity>();

        SubTotal = itens_validos.Sum(item => item.TotalItem);
    }
    public void CalcularTotalPedido()
    {
        CalcularSubTotal();
        Total = SubTotal - Desconto;
        UpdateAt = DateTime.Now;
    }
    public void AlterarTipoPedido(TipoPedidoEnum tipoPedido)
    {
        TipoPedido = tipoPedido;
        UpdateAt = DateTime.Now;
    }
    public void AlterarNumeroPedido(string numeroPedido)
    {
        NumeroPedido = numeroPedido;
        UpdateAt = DateTime.Now;
    }
    public void AdiconarObservacoes(string obervacoes)
    {
        Observacoes += " " + obervacoes;
        UpdateAt = DateTime.Now;
    }
    public void RemoverObservacoes()
    {
        Observacoes = string.Empty;
        UpdateAt = DateTime.Now;
    }
    public void AplicarDescontoPedidoValorReal(decimal? valorDesconto)
    {
        if (valorDesconto <= 0)
            throw new ArgumentException("Valor do desconto não pode ser menor ou igual a zero.");

        if (valorDesconto > SubTotal)
            throw new ArgumentException("Valor do desconto não pode ultrapassar o valor do pedido.");

        Desconto = valorDesconto;

        CalcularTotalPedido();
    }
    public void AplicarDescontoPedidoPercentual(decimal descontoPercentual)
    {
        if (descontoPercentual <= 0)
            throw new ArgumentException("Percentual do desconto não pode ser menor ou igual a zero.");

        if (descontoPercentual > 100)
            throw new ArgumentException("Percentual do desconto não pode ultrapassar de 100%.");

        decimal? valorDescontoReal = SubTotal * (descontoPercentual / 100);

        AplicarDescontoPedidoValorReal(valorDescontoReal);
    }
    public void RemoverDesconto()
    {
        Desconto = 0;
        CalcularTotalPedido();
    }
    public void CancelarPedido()
    {
        if (Cancelado == true)
            throw new ArgumentException("Pedido já está cancelado");

        Cancelado = true;
        UpdateAt = DateTime.Now;
    }
    public void FinalizarPedido()
    {
        if (Finalizado.HasValue)
            throw new ArgumentException("Pedido já esta finalizado");
        Finalizado = true;
        UpdateAt = DateTime.Now;
    }
}

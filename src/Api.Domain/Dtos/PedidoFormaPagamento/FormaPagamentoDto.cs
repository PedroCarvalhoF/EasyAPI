namespace Domain.Dtos.FormaPagamentoDtos
{
    public class FormaPagamentoDto
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Habilitado { get; set; }
        public string? DescricaoFormaPg { get; set; }
        
    }
}

namespace Domain.Dtos.Pessoa.Funcionario.CTPS
{
    public class CtpsDto
    {
        public Guid Id { get; set; }
        public string? NumeroCTPS { get; set; }        
        public string? Serie { get; set; }     
        public string? Digito { get; set; }       
        public string? NumeroPIS { get; set; }
    }
}

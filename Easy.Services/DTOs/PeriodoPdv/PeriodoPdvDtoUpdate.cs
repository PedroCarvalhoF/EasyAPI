namespace Easy.Services.DTOs.PeriodoPdv
{
    public class PeriodoPdvDtoUpdate
    {
        public Guid Id { get; private set; }
        public string DescricaoPeriodo { get; private set; }
        public bool Habilitado { get; private set; }
        public PeriodoPdvDtoUpdate(Guid id, string descricaoPeriodo, bool habilitado)
        {
            Id = id;
            DescricaoPeriodo = descricaoPeriodo;
            Habilitado = habilitado;
        }       
    }
}

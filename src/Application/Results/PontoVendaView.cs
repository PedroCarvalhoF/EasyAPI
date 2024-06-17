namespace Application.Results
{
    public class PontoVendaView
    {
        public PontoVendaView(Guid id, DateTime createAt, DateTime? updateAt, Guid userPdvCreateId, string? nomeUserPdvCreate, Guid userPdvUsingId, string? nomeUserPdvUsing, Guid periodoPontoVendaEntityId, string? descricaoPeriodo, bool abertoFechado)
        {
            Id = id;
            CreateAt = createAt;
            UpdateAt = updateAt;
            UserPdvCreateId = userPdvCreateId;
            NomeUserPdvCreate = nomeUserPdvCreate;
            UserPdvUsingId = userPdvUsingId;
            NomeUserPdvUsing = nomeUserPdvUsing;
            PeriodoPontoVendaEntityId = periodoPontoVendaEntityId;
            DescricaoPeriodo = descricaoPeriodo;
            AbertoFechado = abertoFechado;
        }

        public Guid Id { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }
        public Guid UserPdvCreateId { get; private set; }
        public string? NomeUserPdvCreate { get; private set; }
        public Guid UserPdvUsingId { get; private set; }
        public string? NomeUserPdvUsing { get; private set; }
        public Guid PeriodoPontoVendaEntityId { get; private set; }
        public string? DescricaoPeriodo { get; private set; }
        public bool AbertoFechado { get; private set; }
    }
}

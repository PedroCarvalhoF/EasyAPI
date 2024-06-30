
using Easy.Domain.Entities.PDV.PDV;
using Easy.Domain.Tools;
using Easy.Domain.Tools.Validation;

namespace Easy.Domain.Entities.PDV.Periodo;

public class PeriodoPdvEntity : BaseEntity
{
    public string DescricaoPeriodo { get; private set; }
    public virtual ICollection<PontoVendaEntity> PontosVendas { get; private set; }
    public bool Validada => Validar();
    private bool Validar()
    {
        if (DescricaoPeriodo == string.Empty) return false;
        if (DescricaoPeriodo.Length > 50) return false;

        return true;
    }

    public PeriodoPdvEntity() { }
    PeriodoPdvEntity(string descricaoPeriodo, FiltroBase users) : base(users)
    {
        DomainValidation.When
            (string.IsNullOrEmpty(descricaoPeriodo), "Informe a descrição do período.");
        DomainValidation.When
            (descricaoPeriodo.Length > 50, "Número máximo de caracteres é de 50");

        DescricaoPeriodo = PrimeiraLetraSempreMaiuscula.Formatar(descricaoPeriodo);
    }

    PeriodoPdvEntity(Guid id, bool habilitado, string descricaoPeriodo, FiltroBase users) : base(id, habilitado, users)
    {
        DomainValidation.When(id == Guid.Empty, "Informe o id do período");
        DomainValidation.When(string.IsNullOrEmpty(descricaoPeriodo), "Informe a descrição do período.");
        DomainValidation.When(descricaoPeriodo.Length > 50, "Número máximo de caracteres é de 50");

        DescricaoPeriodo = PrimeiraLetraSempreMaiuscula.Formatar(descricaoPeriodo);
    }

    public static PeriodoPdvEntity Create(string descricaoPeriodo, FiltroBase users)
        => new PeriodoPdvEntity(descricaoPeriodo, users);

    public static PeriodoPdvEntity Update(Guid id, bool habilitado, string descricaoPeriodo, FiltroBase users)
        => new PeriodoPdvEntity(id, habilitado, descricaoPeriodo, users);
}

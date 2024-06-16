using Api.Domain.Entities;
using Api.Domain.Entities.PontoVenda;
using Domain.Helpers.Tools;
using Domain.UserIdentity.Masters;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.PontoVendaPeriodoVenda
{
    public class PeriodoPontoVendaEntity : BaseEntity
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Periodo de Venda")]
        [MaxLength(100, ErrorMessage = "{0} -Número máximo de caracteres")]
        public string? DescricaoPeriodo { get; private set; }
        public virtual ICollection<PontoVendaEntity>? PontoVendaEntities { get; private set; }
        public bool Valida => Validar();
        public PeriodoPontoVendaEntity() { }
        public PeriodoPontoVendaEntity(string? descricaoPeriodo, UserMasterUserDtoCreate users) : base(users)
        {
            if (string.IsNullOrWhiteSpace(descricaoPeriodo))
                throw new ArgumentException("Preencha descrição da categoria");

            DescricaoPeriodo = PrimeiraLetraSempreMaiuscula.Formatar(descricaoPeriodo!);
        }

        public PeriodoPontoVendaEntity(Guid id, bool habilitado, string? descricaoPeriodo, UserMasterUserDtoCreate users) : base(id, habilitado, users)
        {
            if (string.IsNullOrWhiteSpace(descricaoPeriodo))
                throw new ArgumentException("Preencha descrição da categoria");

            DescricaoPeriodo = PrimeiraLetraSempreMaiuscula.Formatar(DescricaoPeriodo!);
        }

     

        private bool Validar()
        {
            if (string.IsNullOrEmpty(this.DescricaoPeriodo))
                return false;
            if (DescricaoPeriodo.Length > 100)
                return false;

            return true;
        }
    }
}

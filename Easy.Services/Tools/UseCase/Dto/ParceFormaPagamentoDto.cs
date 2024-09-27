using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Services.DTOs.FormaPagamento;

namespace Easy.Services.Tools.UseCase.Dto
{
    public partial class DtoMapper
    {
        public static FormaPagamentoDto ParceFormaPagamentoDto(FormaPagamentoEntity formaPagamentoEntity)
        {
            return new FormaPagamentoDto(formaPagamentoEntity.Id, formaPagamentoEntity.DescricaFormaPagamento, formaPagamentoEntity.Codigo, formaPagamentoEntity.Habilitado);
        }

        public static IEnumerable<FormaPagamentoDto> ParceFormaPagamentoDto(IEnumerable<FormaPagamentoEntity> formas)
        {
            foreach (var forma in formas)
            {
                yield return ParceFormaPagamentoDto(forma);
            }
        }
    }
}

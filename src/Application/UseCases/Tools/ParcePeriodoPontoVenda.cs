using Application.UseCases.Commands.PontoVenda.Periodo;
using Domain.Entities.PontoVendaPeriodoVenda;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static PeriodoPontoVendaEntity ParseEndereco(PeriodoCreateCommand comand, UserMasterUserDtoCreate users)
        {
            return
                new PeriodoPontoVendaEntity
                (
                    descricaoPeriodo: comand.DescricaoPeriodo,
                    users: users
                );
        }
    }
}
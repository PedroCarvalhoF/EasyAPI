using Api.Domain.Entities.PontoVenda;
using Application.UseCases.Commands.PontoVenda;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static PontoVendaEntity ParcePontoVenda(PontoVendaCreateCommand command, UserMasterUserDtoCreate users)
        {
            return new PontoVendaEntity(userPdvCreateId: command.UserPdvCreateId,
                                         userPdvUsingId: command.UserPdvUsingId,
                              periodoPontoVendaEntityId: command.PeriodoPontoVendaEntityId,
                                                  users: users);
        }
    }
}

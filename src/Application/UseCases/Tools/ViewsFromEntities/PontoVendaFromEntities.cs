using Api.Domain.Entities.PontoVenda;
using Application.Results;

namespace Application.UseCases.Tools.ViewsFromEntities
{
    public static class PontoVendaFromEntities
    {
        public static List<PontoVendaView> ListPontoVendaView(IEnumerable<PontoVendaEntity> pdvsEntities)
        {
            var pontoVendaListView = new List<PontoVendaView>();
            foreach (var pdv in pdvsEntities)
            {
                pontoVendaListView.Add(
                    new PontoVendaView(id: pdv.Id,
                                 createAt: pdv.CreateAt,
                                 updateAt: pdv.UpdateAt,
                          userPdvCreateId: pdv.UserPdvCreateId,
                        nomeUserPdvCreate: pdv.UserPdvCreate.User.UserName,
                           userPdvUsingId: pdv.UserPdvUsing.Id,
                         nomeUserPdvUsing: pdv.UserPdvUsing.User.Nome,
                periodoPontoVendaEntityId: pdv.PeriodoPontoVendaEntityId,
                         descricaoPeriodo: pdv.PeriodoPontoVendaEntity.DescricaoPeriodo,
                            abertoFechado: pdv.Habilitado));
            }

            return pontoVendaListView;
        }
    }
}

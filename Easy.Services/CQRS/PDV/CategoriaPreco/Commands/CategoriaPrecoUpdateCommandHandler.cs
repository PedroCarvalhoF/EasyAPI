using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;

public class CategoriaPrecoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<CategoriaPrecoUpdateCommand, RequestResultForUpdate>
{
    public async Task<RequestResultForUpdate> Handle(CategoriaPrecoUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categoriaPrecoUpdateEntity = CategoriaPrecoEntity.Update(request.Id, request.Habilitado, request.Codigo, request.DescricaFormaPagamento, request.GetFiltro());

            if (!categoriaPrecoUpdateEntity.isBaseValida)
                return new RequestResultForUpdate().EntidadeInvalida();

            await _repository.CategoriaPrecoRepository.UpdateAsync(categoriaPrecoUpdateEntity, request.GetFiltro());
            var result = await _repository.CommitAsync();
            if (result)
                return new RequestResultForUpdate().Ok("Categora alterada com sucesso.");

            return new RequestResultForUpdate().BadRequest("Não foi possível realizar alteração");

        }
        catch (Exception ex)
        {

            return new RequestResultForUpdate().BadRequest(ex.Message);
        }
    }
}

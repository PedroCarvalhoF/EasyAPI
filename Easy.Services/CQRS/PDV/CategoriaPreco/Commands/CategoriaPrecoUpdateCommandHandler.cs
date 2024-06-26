using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;

public class CategoriaPrecoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<CategoriaPrecoUpdateCommand, RequestResult>
{
    public async Task<RequestResult> Handle(CategoriaPrecoUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categoriaPrecoUpdateEntity = CategoriaPrecoEntity.Update(request.Id, request.Habilitado, request.Codigo, request.DescricaFormaPagamento, request.GetFiltro());

            if (!categoriaPrecoUpdateEntity.isBaseValida)
                return new RequestResult().EntidadeInvalida();

            await _repository.CategoriaPrecoRepository.UpdateAsync(categoriaPrecoUpdateEntity, request.GetFiltro());
            var result = await _repository.CommitAsync();
            if (result)
                return new RequestResult().Ok("Categora alterada com sucesso.");

            return new RequestResult().BadRequest("Não foi possível realizar alteração");

        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}

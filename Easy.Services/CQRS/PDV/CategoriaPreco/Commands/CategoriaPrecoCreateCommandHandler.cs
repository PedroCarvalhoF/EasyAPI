using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;

public class CategoriaPrecoCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<CategoriaPrecoCreateCommand, RequestResult>
{
    public async Task<RequestResult> Handle(CategoriaPrecoCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categoriaPreco = CategoriaPrecoEntity.Create(request.Codigo, request.DescricaFormaPagamento, request.GetFiltro());
            if (!categoriaPreco.isBaseValida)
                return new RequestResult().EntidadeInvalida();

            await _repository.CategoriaPrecoRepository.InsertAsync(categoriaPreco, request.GetFiltro());
            if (await _repository.CommitAsync())
                return new RequestResult().Ok("Categoria de preço criada com sucesso.");

            return new RequestResult().BadRequest();
        }
        catch (Exception ex)
        {

            return new RequestResult().BadRequest(ex.Message);
        }
    }
}

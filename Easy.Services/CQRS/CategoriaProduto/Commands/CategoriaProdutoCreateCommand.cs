using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.CategoriaProduto.Commands;

public class CategoriaProdutoCreateCommand : IRequest<RequestResult>
{
    public CategoriaProdutoCreateCommand(string descricaoCategoria)
    {
        DescricaoCategoria = descricaoCategoria;        
    }

    public string DescricaoCategoria { get; private set; }

    FiltroBase Filtro { get;  set; }

    public void AplicarFiltro(FiltroBase filtro)
        => Filtro = filtro;

    public class CategoriaProdutoCreateCommandHandler : IRequestHandler<CategoriaProdutoCreateCommand, RequestResult>
    {
        private readonly IUnitOfWork _repository;

        public CategoriaProdutoCreateCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult> Handle(CategoriaProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaEntity = new CategoriaProdutoEntity(request.DescricaoCategoria, request.Filtro);

                await _repository.CategoriaProdutoRepository.AddCategoriaAsync(categoriaEntity, request.Filtro);
                var resultCreate = await _repository.CommitAsync();
                if (resultCreate)
                    return new RequestResult().Ok("Categoria cadastrada com sucesso!");

                return new RequestResult().BadUpdate("Não foi possível realizar cadastro da categoria");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}

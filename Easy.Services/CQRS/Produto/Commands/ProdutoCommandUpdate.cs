using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands;

public class ProdutoCommandUpdate : BaseCommands<ProdutoDto>
{
    public ProdutoDtoUpdate prod { get; set; }
    public class ProdutoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<ProdutoCommandUpdate, RequestResult<ProdutoDto>>
    {
        public async Task<RequestResult<ProdutoDto>> Handle(ProdutoCommandUpdate request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var produtoUpdateEntity = ProdutoEntity.Update(request.prod.Id, request.prod.Habilitado, request.prod.NomeProduto, request.prod.Codigo, request.prod.Descricao, request.prod.Observacoes, request.prod.ImagemUrl, request.prod.CategoriaProdutoEntityId, request.prod.MedidaProdutoEnum, request.prod.TipoProdutoEnum, filtro);

                var nomeExists = await _repository.ProdutoRepository.NomeProdutoExists(request.prod.NomeProduto, filtro);

                if (nomeExists.Id != Guid.Empty)
                {
                    //encontrou produto com mesmo nome

                    if (nomeExists.Id != produtoUpdateEntity.Id)
                    {
                        return RequestResult<ProdutoDto>.BadRequest("Nome do produto ja está em uso");
                    }
                }


                var codigoExists = await _repository.ProdutoRepository.CodigoProdutoExists(request.prod.Codigo, filtro);

                if (codigoExists.Id != Guid.Empty)
                {
                    if (codigoExists.Id != produtoUpdateEntity.Id)
                    {
                        return RequestResult<ProdutoDto>.BadRequest("Código do produto ja está em uso");
                    }
                }

                await _repository.ProdutoRepository.UpdateAsync(produtoUpdateEntity, request.GetFiltro());
                var commitResult = await _repository.CommitAsync();
                if (!commitResult)
                    return RequestResult<ProdutoDto>.BadRequest();

                return RequestResult<ProdutoDto>.Ok();
            }
            catch (Exception ex)
            {

                return RequestResult<ProdutoDto>.BadRequest(ex.Message);
            }
        }
    }

}

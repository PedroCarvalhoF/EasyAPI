using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands
{
    public class ProdutoUpdateCommand : BaseCommands<ProdutoDto>
    {
        public required ProdutoDtoUpdate ProdutoDtoUpdate { get; set; }

        public class ProdutoUpdateCommandHandler(IProdutoDapperRepository<FiltroBase> _dapperRepository, IUnitOfWork _repository) : IRequestHandler<ProdutoUpdateCommand, RequestResult<ProdutoDto>>
        {
            public async Task<RequestResult<ProdutoDto>> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var filtro = request.GetFiltro();

                    var produtoEntityUpdate =
                        ProdutoEntity.Update(id: request.ProdutoDtoUpdate.Id,
                                     habilitado: request.ProdutoDtoUpdate.Habilitado,
                                    nomeProduto: request.ProdutoDtoUpdate.NomeProduto,
                                         codigo: request.ProdutoDtoUpdate.Codigo,
                                      descricao: request.ProdutoDtoUpdate.Descricao,
                                    observacoes: request.ProdutoDtoUpdate.Observacoes,
                                      imagemUrl: null,   //Alteração da imagemUrl apenas via requisição - necessário passar nova imagem 
                       categoriaProdutoEntityId: request.ProdutoDtoUpdate.CategoriaProdutoEntityId,
                              medidaProdutoEnum: request.ProdutoDtoUpdate.MedidaProdutoEnum,
                                tipoProdutoEnum: request.ProdutoDtoUpdate.TipoProdutoEnum, filtro);

                    var produtoExists = await _dapperRepository.GetProdutoByIdAsync(filtro, produtoEntityUpdate.Id);

                    if (!produtoExists.Any())
                        return new RequestResult<ProdutoDto>().Erro("Não foi possível realizar alteração do produto.Detalhes: Produto não foi localizado.");

                    produtoEntityUpdate.SetImageUrl(produtoExists.Single().ImagemUrl);

                    var codigoExists = await _dapperRepository.GetProdutosByCodigoAsync(filtro, produtoEntityUpdate.Codigo!);
                    if (codigoExists.Any())
                    {
                        if (codigoExists.Single().ProdutoId != produtoEntityUpdate.Id)
                            return new RequestResult<ProdutoDto>().Erro("Não foi possível realizar alteração do produto.Detalhes: Código já esta em uso.");
                    }

                    var nomeExists = await _dapperRepository.GetProdutosByNomeDescricaoEqualsAsync(filtro, produtoEntityUpdate.NomeProduto!);
                    if (nomeExists.Any())
                        if (nomeExists.Single().ProdutoId != produtoEntityUpdate.Id)
                            return new RequestResult<ProdutoDto>().Erro("Não foi possível realizar alteração do produto.Detalhes: Nome já esta em uso.");


                    await _repository.ProdutoBaseRepository.Update(produtoEntityUpdate);

                    if (!await _repository.CommitAsync())
                        return new RequestResult<ProdutoDto>().ErroSalvarNoBanco();

                    var produtoUpdateResult = await _dapperRepository.GetProdutoByIdAsync(filtro, produtoEntityUpdate.Id);
                    if (!produtoUpdateResult.Any())
                        return new RequestResult<ProdutoDto>().Erro("Erro inesperado.");

                    var dto = DtoMapper.ParceProdutoDto(produtoUpdateResult.Single());

                    return new RequestResult<ProdutoDto>().ResultOk(dto);

                }
                catch (Exception ex)
                {

                    return new RequestResult<ProdutoDto>().Erro(ex);
                }
            }
        }
    }
}

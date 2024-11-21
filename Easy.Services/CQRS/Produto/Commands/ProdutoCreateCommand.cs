using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands;

public class ProdutoCreateCommand : BaseCommands<ProdutoDto>
{
    public required ProdutoDtoCreate ProdutoDtoCreate { get; set; }

    public class ProdutoCreateCommandHandler(IUnitOfWork _repository, IProdutoDapperRepository<FiltroBase> _dapperRepository) : IRequestHandler<ProdutoCreateCommand, RequestResult<ProdutoDto>>
    {
        public async Task<RequestResult<ProdutoDto>> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var produtoCreateEntity =
                    ProdutoEntity.Create(
                        nomeProduto: request.ProdutoDtoCreate.NomeProduto,
                             codigo: request.ProdutoDtoCreate.Codigo,
                          descricao: request.ProdutoDtoCreate.Descricao,
                        observacoes: request.ProdutoDtoCreate.Observacoes,
                          //imagemUrl: request.ProdutoDtoCreate.ImagemUrl,
           categoriaProdutoEntityId: request.ProdutoDtoCreate.CategoriaProdutoEntityId,
                  medidaProdutoEnum: request.ProdutoDtoCreate.MedidaProdutoEnum, tipoProdutoEnum: request.ProdutoDtoCreate.TipoProdutoEnum,
                              users: filtro);

                var codigoProdutoExists = await _dapperRepository.GetProdutosByCodigoAsync(filtro, produtoCreateEntity.Codigo!);
                if (codigoProdutoExists.Any())
                    return new RequestResult<ProdutoDto>().Erro("Código do produto já esta em uso.");

                var nomeProdutoExists = await _dapperRepository.GetProdutosByNomeDescricaoContainsAsync(filtro, produtoCreateEntity.NomeProduto!);
                if (nomeProdutoExists.Any())
                    return new RequestResult<ProdutoDto>().Erro("Nome do produto já esta em uso.");

                await _repository.ProdutoBaseRepository.InsertAsync(produtoCreateEntity);
                if (!await _repository.CommitAsync())
                    return new RequestResult<ProdutoDto>().ErroSalvarNoBanco();

                var produtoCreateSucces = await _dapperRepository.GetProdutoByIdAsync(filtro, produtoCreateEntity.Id);
                if (produtoCreateSucces.Any())
                {
                    var produtoEntityViewBD = produtoCreateSucces.Single();
                    var dto = DtoMapper.ParceProdutoDto(produtoEntityViewBD);

                    return new RequestResult<ProdutoDto>().ResultOk(dto);
                }

                return new RequestResult<ProdutoDto>().Erro("Não foí possível concluir operação");
            }
            catch (Exception ex)
            {

                return new RequestResult<ProdutoDto>().Erro(ex);
            }
        }
    }
}

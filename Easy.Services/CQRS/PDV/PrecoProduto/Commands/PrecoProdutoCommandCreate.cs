using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.PDV.PrecoProduto;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PrecoProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Commands;

public class PrecoProdutoCommandCreate : BaseCommands<PrecoProdutoDto>
{
    public required PrecoProdutoDtoCreate PrecoProdutoDtoCreate { get; set; }

    public class PrecoProdutoCommandCreateHandler(IUnitOfWork _repository, IPrecoProdutoDapperRepository<FiltroBase, PrecoProdutoEntityFilterDapper> _dapperRepository) : IRequestHandler<PrecoProdutoCommandCreate, RequestResult<PrecoProdutoDto>>
    {
        public async Task<RequestResult<PrecoProdutoDto>> Handle(PrecoProdutoCommandCreate request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var precoProdutoEntity =
                   PrecoProdutoEntity.Create(produtoEntityId: request.PrecoProdutoDtoCreate.ProdutoEntityId,
                                      categoriaPrecoEntityId: request.PrecoProdutoDtoCreate.CategoriaPrecoEntityId,
                                                       preco: request.PrecoProdutoDtoCreate.Preco,
                                                      filtro: filtro);

                var precoProdutoExists = await _dapperRepository.
                    GetPrecoProdutoFilterAsync(filtro: filtro,
                                         filtroDapper: new PrecoProdutoEntityFilterDapper
                                         {
                                             CategoriaPrecoid = request.PrecoProdutoDtoCreate.CategoriaPrecoEntityId,
                                             IdProduto = request.PrecoProdutoDtoCreate.ProdutoEntityId
                                         });

                if (precoProdutoExists.Any())
                {
                    var precoProdutoUpdate = PrecoProdutoEntity.Update(id: precoProdutoExists.Single().PrecoProdutoId,
                                                               habilitado: precoProdutoExists.Single().PrecoHabilitado,
                                                          produtoEntityId: request.PrecoProdutoDtoCreate.ProdutoEntityId,
                                                   categoriaPrecoEntityId: request.PrecoProdutoDtoCreate.CategoriaPrecoEntityId,
                                                                    preco: request.PrecoProdutoDtoCreate.Preco,
                                                                   filtro: filtro);

                    if (!precoProdutoEntity.Validada)
                        return new RequestResult<PrecoProdutoDto>().EntidadeInvalida();

                    await _repository.PrecoProdutoBaseRepository.Update(precoProdutoUpdate);
                }
                else
                {
                    if (!precoProdutoEntity.Validada)
                        return new RequestResult<PrecoProdutoDto>().EntidadeInvalida();
                    //casdastrar
                    await _repository.PrecoProdutoBaseRepository.InsertAsync(precoProdutoEntity);
                }

                if (!await _repository.CommitAsync())
                    return new RequestResult<PrecoProdutoDto>().ErroSalvarNoBanco();

                var precoProdutoResultCreateUpdate = (await _dapperRepository.
                                         GetPrecoProdutoFilterAsync(filtro: filtro,
                                         filtroDapper: new PrecoProdutoEntityFilterDapper
                                         {
                                             CategoriaPrecoid = request.PrecoProdutoDtoCreate.CategoriaPrecoEntityId,
                                             IdProduto = request.PrecoProdutoDtoCreate.ProdutoEntityId
                                         })).SingleOrDefault();

                if (precoProdutoResultCreateUpdate == null)
                    return new RequestResult<PrecoProdutoDto>().Erro("Erro inesperado");


                var dto = DtoMapper.ParcePrecoProdutoDto(precoProdutoResultCreateUpdate);

                return new RequestResult<PrecoProdutoDto>().ResultOk(dto);

            }
            catch (Exception ex)
            {

                return new RequestResult<PrecoProdutoDto>().Erro(ex);
            }
        }
    }
}

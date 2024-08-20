using Easy.Domain.Entities.PDV.PrecoProduto;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.PrecoProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.PrecoProduto.Commands;

public class PrecoProdutoCommand : BaseCommands<PrecoProdutoDtoView>
{
    public required PrecoProdutoDtoCreate PrecoProdutoDtoCreate { get; set; }

    public class PrecoProdutoCommandHandler(IUnitOfWork _repository) : IRequestHandler<PrecoProdutoCommand, RequestResult<PrecoProdutoDtoView>>
    {
        public async Task<RequestResult<PrecoProdutoDtoView>> Handle(PrecoProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = request.GetFiltro();

                var precoProdutoExists = await
                    _repository.PrecoProdutoRepository.SelectAsync(request.PrecoProdutoDtoCreate.ProdutoEntityId, request.PrecoProdutoDtoCreate.CategoriaPrecoEntityId, users);

                if (precoProdutoExists.Id == Guid.Empty)
                {
                    var precoProdutoCreate = PrecoProdutoEntity.Create(request.PrecoProdutoDtoCreate.ProdutoEntityId, request.PrecoProdutoDtoCreate.CategoriaPrecoEntityId, request.PrecoProdutoDtoCreate.Preco, users);

                    if (!precoProdutoCreate.isBaseValida)
                        return RequestResult<PrecoProdutoDtoView>.BadRequest();

                    await _repository.PrecoProdutoRepository.InsertAsync(precoProdutoCreate, users);
                    if (await _repository.CommitAsync())
                    {
                        var precoEntity = await _repository.PrecoProdutoRepository.SelectAsync(precoProdutoCreate.ProdutoEntityId, precoProdutoCreate.CategoriaPrecoEntityId, users);



                        return RequestResult<PrecoProdutoDtoView>.Ok(DtoMapper.ParcePrecoProduto(precoEntity));
                    }

                }
                else
                {
                    var precoProdutoUpdate = PrecoProdutoEntity.Update(precoProdutoExists.Id, true, precoProdutoExists.ProdutoEntityId, precoProdutoExists.CategoriaPrecoEntityId, request.PrecoProdutoDtoCreate.Preco, users);

                    if (!precoProdutoUpdate.isBaseValida)
                        return RequestResult<PrecoProdutoDtoView>.BadRequest();

                    await _repository.PrecoProdutoRepository.UpdatePreco(precoProdutoUpdate, users);
                    if (await _repository.CommitAsync())
                    {
                        var precoEntity = await _repository.PrecoProdutoRepository.SelectAsync(precoProdutoUpdate.ProdutoEntityId, precoProdutoUpdate.CategoriaPrecoEntityId, users);
                        
                        return RequestResult<PrecoProdutoDtoView>.Ok(DtoMapper.ParcePrecoProduto(precoEntity));
                    }
                }


                return RequestResult<PrecoProdutoDtoView>.BadRequest();

            }
            catch (Exception ex)
            {

                return RequestResult<PrecoProdutoDtoView>.BadRequest(ex.Message);
            }
            finally
            {
                _repository.FinalizarContexto();
            }
        }
    }

}

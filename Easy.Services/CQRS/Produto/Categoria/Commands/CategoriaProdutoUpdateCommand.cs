using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Commands;

public class CategoriaProdutoUpdateCommand : BaseCommands<CategoriaProdutoDto>
{
    public required CategoriaProdutoDtoUpdate CategoriaProdutoDtoUpdate { get; set; }
    public class CategoriaProdutoUpdateCommandHandler(IUnitOfWork _repository, ICategoriaProdutoDapperRepository<FiltroBase> _dapperRepository) : IRequestHandler<CategoriaProdutoUpdateCommand, RequestResult<CategoriaProdutoDto>>
    {
        public async Task<RequestResult<CategoriaProdutoDto>> Handle(CategoriaProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var categoriaProdutoForUpdate = CategoriaProdutoEntity.Update(request.CategoriaProdutoDtoUpdate.Id, request.CategoriaProdutoDtoUpdate.Habilitado, request.CategoriaProdutoDtoUpdate.DescricaoCategoria, filtro);
                if (!categoriaProdutoForUpdate.Validada)
                    return RequestResult<CategoriaProdutoDto>.EntidadeInvalida();

                var categoriaProdutoExists = await _dapperRepository.GetCategoriaProdutoByIdCategoria(request.CategoriaProdutoDtoUpdate.Id, filtro);

                if (categoriaProdutoExists == null)
                    return new RequestResult<CategoriaProdutoDto>().Erro("Categoria de produto não localizada.");

                //verificar se descricao da categoria alterada ja exist
                var categoriaDescricaoExists = (await _dapperRepository.GetCategoriaProdutoEqualsCategoriaQuery(filtro, categoriaProdutoForUpdate.DescricaoCategoria)).SingleOrDefault();

                if (categoriaDescricaoExists != null)
                    if (categoriaProdutoForUpdate.Id != categoriaDescricaoExists.Id)
                        return new RequestResult<CategoriaProdutoDto>().Erro("Descrição da categoria já esta em uso");

                await _repository.CategoriaProdutoBaseRepository.Update(categoriaProdutoForUpdate);
                if (!await _repository.CommitAsync())
                    return RequestResult<CategoriaProdutoDto>.FalhaCommitRepository();

                var dto = DtoMapper.ParceCategoriaProdutoDto(categoriaProdutoForUpdate);
                return new RequestResult<CategoriaProdutoDto>().ResultOk(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaProdutoDto>.BadRequest(ex.Message);
            }
        }
    }
}

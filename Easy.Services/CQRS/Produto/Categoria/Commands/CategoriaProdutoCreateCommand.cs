using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Commands;

public class CategoriaProdutoCreateCommand : BaseCommands<CategoriaProdutoDto>
{
    public required CategoriaProdutoDtoCreate CategoriaProdutoDtoCreate { get; set; }
    public class CategoriaProdutoCreateCommandHandler(IUnitOfWork _repository, ICategoriaProdutoDapperRepository<FiltroBase> _dapperRespository) : IRequestHandler<CategoriaProdutoCreateCommand, RequestResult<CategoriaProdutoDto>>
    {
        public async Task<RequestResult<CategoriaProdutoDto>> Handle(CategoriaProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var categoriaProdutoCreate = CategoriaProdutoEntity.Create(request.CategoriaProdutoDtoCreate.DescricaoCategoria, filtro);
                if (!categoriaProdutoCreate.isBaseValida)
                    return RequestResult<CategoriaProdutoDto>.BadRequest("Entidade inválida.");


                var categoriaExists = (await _dapperRespository.GetCategoriaProdutoEqualsCategoriaQuery(filtro, categoriaProdutoCreate.DescricaoCategoria)).SingleOrDefault();
                if (categoriaExists != null)
                    return new RequestResult<CategoriaProdutoDto>().Erro("Descrição da categoria ja existe.");

                await _repository.CategoriaProdutoBaseRepository.InsertAsync(categoriaProdutoCreate);
                if (!await _repository.CommitAsync())
                    return new RequestResult<CategoriaProdutoDto>().ErroSalvarNoBanco();

                var dto = DtoMapper.ParceCategoriaProdutoDto(categoriaProdutoCreate);

                return new RequestResult<CategoriaProdutoDto>().ResultOk(dto);

            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaProdutoDto>.BadRequest(ex.Message);
            }
        }
    }
}

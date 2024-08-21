using AutoMapper;
using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.Produto.Categoria;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Commands;

public class CategoriaProdutoUpdateCommand : BaseCommands<CategoriaProdutoDtoView>
{
    public Guid Id { get; set; }
    public bool Habilitado { get; set; }
    public string DescricaoCategoria { get; set; }

    public class CategoriaProdutoUpdateCommandHandler : IRequestHandler<CategoriaProdutoUpdateCommand, RequestResult<CategoriaProdutoDtoView>>
    {
        private readonly IUnitOfWork _repository;
        private readonly ICategoriaProdutoDapperRepository<FiltroBase> _dapperRepository;
        private readonly IMapper _mapper;

        public CategoriaProdutoUpdateCommandHandler(IUnitOfWork repository, ICategoriaProdutoDapperRepository<FiltroBase> dapperRepository, IMapper mapper)
        {
            _repository = repository;
            _dapperRepository = dapperRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult<CategoriaProdutoDtoView>> Handle(CategoriaProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();
                var categoriaProdutoForUpdate = CategoriaProdutoEntity.Update(request.Id, request.Habilitado, request.DescricaoCategoria, filtro);
                if (!categoriaProdutoForUpdate.Validada)
                    return RequestResult<CategoriaProdutoDtoView>.BadRequest("Entidade inválida.");

                 _repository.CategoriaProdutoBaseRepository.Update(categoriaProdutoForUpdate);
                if (!await _repository.CommitAsync())
                    return RequestResult<CategoriaProdutoDtoView>.BadRequest("Não foi possível alterar categoria do produto.");

                var categoriaEntity = await _dapperRepository.GetCategoriaProdutoById(categoriaProdutoForUpdate.Id, filtro);
                if (categoriaEntity == null)
                    return RequestResult<CategoriaProdutoDtoView>.BadRequest("Não foi possível localizar categoria do produto");

                var categoriaDto = _mapper.Map<CategoriaProdutoDtoView>(categoriaEntity);

                return RequestResult<CategoriaProdutoDtoView>.Ok(categoriaDto, "Categoria do produto alterada com sucesso.");
            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaProdutoDtoView>.BadRequest(ex.Message);
            }
        }
    }
}

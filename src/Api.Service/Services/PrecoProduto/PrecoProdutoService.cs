using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PrecoProduto;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.UserIdentity.Masters;

namespace Api.Service.Services.PrecoProduto
{
    public class PrecoProdutoService : IPrecoProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<PrecoProdutoEntity> _repository;
        private readonly IPrecoProdutoRepository _implementacao;

        public PrecoProdutoService(IMapper mapper, IBaseRepository<PrecoProdutoEntity> repository, IPrecoProdutoRepository precoProdutoRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _implementacao = precoProdutoRepository;
        }
        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao.GetAll(users);
                if (entities == null || entities.Count() == 0)
                    return new RequestResult().IsNullOrCountZero();

                var precosViews = new List<PrecoProdutoView>();

                foreach (var prp in entities)
                {
                    precosViews.Add(new PrecoProdutoView(prp.Id, prp.ProdutoEntity.NomeProduto, prp.CategoriaPrecoEntity.DescricaoCategoria, prp.PrecoProduto));
                }

                return new RequestResult().Ok(precosViews);
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> CreateUpdate(PrecoProdutoDtoCreate create, UserMasterUserDtoCreate users)
        {
            try
            {
                var precoExists = await _implementacao.PrecoProdutoExists(create, users);
                if (precoExists == null)
                {
                    //create
                    var entity = new PrecoProdutoEntity(create, users);
                    if (!entity.Valida)
                        return new RequestResult().EntidadeInvalida();

                    var entityResultCreate = await _repository.InsertAsync(entity);
                    if (entityResultCreate == null)
                        return new RequestResult().BadCreate();

                    var precoCreate = await _implementacao.PrecoProdutoExists(create, users);

                    var precoProdutoDtoResult = new PrecoProdutoDtoCreateResult(precoCreate.Id, precoCreate.ProdutoEntity.NomeProduto, precoCreate.CategoriaPrecoEntity.DescricaoCategoria, precoCreate.PrecoProduto);

                    return new RequestResult().Ok(precoProdutoDtoResult);
                }
                else
                {
                    //update

                    var precoUpdate = new PrecoProdutoDtoUpdate
                    {
                        Id = precoExists.Id,
                        Habilitado = true,
                        PrecoProduto = create.PrecoProduto,
                        CategoriaPrecoEntityId = create.CategoriaPrecoEntityId,
                        ProdutoEntityId = create.ProdutoEntityId
                    };

                    var entityUpdate = new PrecoProdutoEntity(precoUpdate, users);
                    if (!entityUpdate.Valida)
                        return new RequestResult().EntidadeInvalida();

                    var entityUpdateResult = await _repository.UpdateAsync(entityUpdate);
                    if (entityUpdateResult == null)
                        return new RequestResult().BadCreate();

                    var precoCreate = await _implementacao.PrecoProdutoExists(create, users);

                    var precoProdutoDtoResult = new PrecoProdutoDtoCreateResult(precoCreate.Id, precoCreate.ProdutoEntity.NomeProduto, precoCreate.CategoriaPrecoEntity.DescricaoCategoria, precoCreate.PrecoProduto);

                    return new RequestResult().Ok(precoProdutoDtoResult);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }


    }
}
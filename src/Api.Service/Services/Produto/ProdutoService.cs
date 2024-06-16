using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.ProdutoDtos;
using Domain.Dtos.Produtos;
using Domain.Entities.Produto;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Produto;
using Domain.Interfaces.Services.Produto;
using Domain.UserIdentity.Masters;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace Service.Services.Produto
{
    public class ProdutoService : IProdutoService

    {
        private readonly IBaseRepository<ProdutoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _implementacao;
        public ProdutoService(IBaseRepository<ProdutoEntity> repository, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = produtoRepository;
        }
        public async Task<RequestResult> GetAll(UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao.GetAll(users);
                if (entities == null || entities.Count() == 0)
                    return new RequestResult().IsNullOrCountZero();

                var ProdutosViews = new Collection<ProdutoView>();

                foreach (var pr in entities)
                {
                    ProdutosViews.Add(new ProdutoView(pr.Id, pr.NomeProduto, pr.CodigoBarrasPersonalizado, pr.CategoriaProdutoEntity.DescricaoCategoria, pr.ProdutoMedidaEntity.Descricao, pr.ProdutoTipoEntity.DescricaoTipoProduto, pr.ImgUrl));
                }
                return new RequestResult().Ok(ProdutosViews);
                return new RequestResult().Ok(_mapper.Map<IEnumerable<ProdutoDto>>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> GetByIdProduto(Guid id, UserMasterUserDtoCreate users)
        {
            try
            {
                var entities = await _implementacao!.GetByIdProduto(id, users);
                if (entities == null)
                    return new RequestResult().IsNullOrCountZero();

                return new RequestResult().Ok(_mapper!.Map<ProdutoDto>(entities));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Create(ProdutoDtoCreate create, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new ProdutoEntity(create, users);
                if (!entity.Validada)
                    return new RequestResult().EntidadeInvalida();

                bool codigoProduto = await _implementacao.CodigoExists(create.CodigoBarrasPersonalizado, users);
                if (codigoProduto)
                    return new RequestResult().BadRequest("Código em uso");

                bool nomeProduto = await _implementacao.NomeProdutoExists(create.NomeProduto, users);
                if (nomeProduto)
                    return new RequestResult().BadRequest("Nome do produto em uso");


                var entityResult = await _repository.InsertAsync(entity);
                if (entityResult == null)
                    return new RequestResult().BadRequest("Não foi possível cadastrar");

                return new RequestResult().Ok(_mapper.Map<ProdutoDtoCreateResult>(entityResult));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
        public async Task<RequestResult> Update(ProdutoDtoUpdate update, UserMasterUserDtoCreate users)
        {
            try
            {
                var entity = new ProdutoEntity(update, users);
                if (!entity.Validada)
                    return new RequestResult().EntidadeInvalida();

                var entityResult = await _repository.UpdateAsync(entity);
                if (entityResult == null)
                    return new RequestResult().BadRequest("Não foi possível cadastrar");

                return new RequestResult().Ok(_mapper.Map<ProdutoDtoCreateResult>(entityResult));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
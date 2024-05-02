using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Api.Domain.Models.PrecoProdutoModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Api.Service.Services.PrecoProduto
{
    public class PrecoProdutoService : IPrecoProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PrecoProdutoEntity> _repository;
        private readonly IPrecoProdutoRepository _implementacao;

        public PrecoProdutoService(IMapper mapper, IRepository<PrecoProdutoEntity> repository, IPrecoProdutoRepository precoProdutoRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _implementacao = precoProdutoRepository;
        }
        public async Task<IEnumerable<PrecoProdutoDto>> GetAll()
        {
            try
            {
                IEnumerable<PrecoProdutoEntity> entities = await _implementacao.GetAll();
                IEnumerable<PrecoProdutoDto> dtos = _mapper.Map<IEnumerable<PrecoProdutoDto>>(entities);
                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<PrecoProdutoDto> Get(Guid id)
        {
            try
            {
                PrecoProdutoEntity entity = await _implementacao.Get(id);
                PrecoProdutoDto dto = _mapper.Map<PrecoProdutoDto>(entity);
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PrecoProdutoDto>> GetProdutoId(Guid id)
        {
            try
            {
                IEnumerable<PrecoProdutoEntity> entities = await _implementacao.GetProdutoId(id);
                IEnumerable<PrecoProdutoDto> dtos = _mapper.Map<IEnumerable<PrecoProdutoDto>>(entities);
                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<PrecoProdutoDto>> GetCategoriaPrecoId(Guid id)
        {
            try
            {
                IEnumerable<PrecoProdutoEntity> entities = await _implementacao.GetCategoriaPrecoId(id);
                IEnumerable<PrecoProdutoDto> dtos = _mapper.Map<IEnumerable<PrecoProdutoDto>>(entities);
                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PrecoProdutoDto> CreateUpdate(PrecoProdutoDtoCreate createUpdate)
        {
            try
            {
                PrecoProdutoModel model = _mapper.Map<PrecoProdutoModel>(createUpdate);
                PrecoProdutoEntity entidade = _mapper.Map<PrecoProdutoEntity>(model);
                PrecoProdutoEntity? precoExists = await _implementacao.PrecoExists(model.ProdutoEntityId, model.CategoriaPrecoEntityId);



                if (precoExists is null)
                {
                    //cadastrar                    
                    PrecoProdutoEntity result = await _repository.InsertAsync(entidade);
                    return await Get(result.Id);
                }
                else
                {
                    //alterar
                    entidade.Id = precoExists.Id;
                    entidade.Habilitado = true;
                    PrecoProdutoEntity result = await _repository.UpdateAsync(entidade);
                    return await Get(result.Id);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
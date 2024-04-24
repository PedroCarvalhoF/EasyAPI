using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Api.Domain.Models.PrecoProdutoModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Repository;

namespace Api.Service.Services.PrecoProduto
{
    public class PrecoProdutoService : IPrecoProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PrecoProdutoEntity> _repository;
        private readonly IPrecoProdutoRepository precoProdutoRepository;

        public PrecoProdutoService(IMapper mapper, IRepository<PrecoProdutoEntity> repository, IPrecoProdutoRepository precoProdutoRepository)
        {
            _mapper = mapper;
            _repository = repository;
            this.precoProdutoRepository = precoProdutoRepository;
        }
        public async Task<PrecoProdutoDto> CadastrarPrecoProduto(PrecoProdutoDtoCreate preco)
        {
            try
            {
                //se existir altera

                PrecoProdutoEntity precoProdutoExists = await precoProdutoRepository.GetExistPrecoProduto(preco.ProdutoEntityId, preco.CategoriaPrecoEntityId);

                PrecoProdutoEntity precoProdutoEntity = null;
                if (precoProdutoExists == null)// se naõ existir cadastrar preço novo
                {
                    PrecoProdutoModels model = _mapper.Map<PrecoProdutoModels>(preco);
                    model.Habilitado = true;
                    PrecoProdutoEntity entity = _mapper.Map<PrecoProdutoEntity>(model);
                    precoProdutoEntity = await _repository.InsertAsync(entity);
                }
                else // se ja existir altera apenas o update preço
                {
                    PrecoProdutoModels model = _mapper.Map<PrecoProdutoModels>(preco);
                    model.Id = precoProdutoExists.Id;
                    model.Habilitado = preco.Habilitado;

                    PrecoProdutoEntity entity = _mapper.Map<PrecoProdutoEntity>(model);
                    precoProdutoEntity = await _repository.UpdateAsync(entity);
                }

                return await ConsultarPrecoByID(precoProdutoEntity.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PrecoProdutoDto> ConsultarPrecoByID(Guid id)
        {
            try
            {
                PrecoProdutoEntity result = await precoProdutoRepository.ConsultarPrecoByID(id);
                return _mapper.Map<PrecoProdutoDto>(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PrecoProdutoDto>> ConsultarPrecoProduto()
        {
            try
            {
                IEnumerable<PrecoProdutoEntity> entities = await precoProdutoRepository.Get(pr => pr.Id != Guid.Empty, true);

                IEnumerable<PrecoProdutoDto> dtos = _mapper.Map<IEnumerable<PrecoProdutoDto>>(entities);

                return dtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PrecoProdutoDto>> GetPrecosByCategoriaPrecoID(Guid categoriaId)
        {
            try
            {
                IEnumerable<PrecoProdutoEntity> entities = await precoProdutoRepository.Get(pr => pr.CategoriaPrecoEntityId.Equals(categoriaId), true);

                IEnumerable<PrecoProdutoDto> dtos = _mapper.Map<IEnumerable<PrecoProdutoDto>>(entities);

                return dtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PrecoProdutoDto>> GetPrecosByProdutoID(Guid produtoId)
        {
            try
            {
                IEnumerable<PrecoProdutoEntity> entities = await precoProdutoRepository.Get(pr => pr.ProdutoEntityId.Equals(produtoId), true);

                IEnumerable<PrecoProdutoDto> dtos = _mapper.Map<IEnumerable<PrecoProdutoDto>>(entities);

                return dtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}
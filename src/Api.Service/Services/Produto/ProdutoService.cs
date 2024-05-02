using AutoMapper;
using Domain.Dtos.ProdutoDtos;
using Domain.Entities.Produto;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services.Produto;
using Domain.Models.ProdutoModels;

namespace Service.Services.Produto
{
    public class ProdutoService : IProdutoService

    {
        private readonly IRepository<ProdutoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _implementacao;
        public ProdutoService(IRepository<ProdutoEntity> repository, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = produtoRepository;
        }



        public async Task<IEnumerable<ProdutoDto>> Get()
        {
            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.Get();
                return _mapper.Map<IEnumerable<ProdutoDto>>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProdutoDto> Get(Guid id)
        {
            try
            {
                ProdutoEntity entities = await _implementacao.Get(id);
                return _mapper.Map<ProdutoDto>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> Get(string nomeProduto)
        {
            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.Get(nomeProduto);
                return _mapper.Map<IEnumerable<ProdutoDto>>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetCategoria(Guid categoriaId)
        {
            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.GetCategoria(categoriaId);
                return _mapper.Map<IEnumerable<ProdutoDto>>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProdutoDto> GetCodigo(string codigoPersonalizado)
        {
            try
            {
                ProdutoEntity entities = await _implementacao.GetCodigo(codigoPersonalizado);
                return _mapper.Map<ProdutoDto>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetHabilitadoNaoHabilitado(bool habilitado)
        {
            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.GetHabilitadoNaoHabilitado(habilitado);
                return _mapper.Map<IEnumerable<ProdutoDto>>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetMedida(Guid categoriaId)
        {
            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.GetMedida(categoriaId);
                return _mapper.Map<IEnumerable<ProdutoDto>>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> GetProdutoTipo(Guid categoriaId)
        {
            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.GetProdutoTipo(categoriaId);
                return _mapper.Map<IEnumerable<ProdutoDto>>(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ProdutoDto> Cadastrar(ProdutoDtoCreate produtoDtoCreate)
        {
            try
            {
                ProdutoModel model = _mapper.Map<ProdutoModel>(produtoDtoCreate);
                ProdutoEntity entity = _mapper.Map<ProdutoEntity>(model);
                ProdutoEntity result = await _repository.InsertAsync(entity);
                return _mapper.Map<ProdutoDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProdutoDto> Alterar(ProdutoDtoUpdate produtoDtoUpdate)
        {
            try
            {
                ProdutoModel model = _mapper.Map<ProdutoModel>(produtoDtoUpdate);

                model.Update();

                ProdutoEntity entity = _mapper.Map<ProdutoEntity>(model);
                ProdutoEntity result = await _repository.UpdateAsync(entity);
                return _mapper.Map<ProdutoDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

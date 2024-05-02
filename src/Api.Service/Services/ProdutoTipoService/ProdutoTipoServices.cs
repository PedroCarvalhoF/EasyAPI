using AutoMapper;
using Domain.Dtos.ProdutoTipo;
using Domain.Entities.ProdutoTipo;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Produto;
using Domain.Interfaces.Services.ProdutoTipo;
using Domain.Models.ProdutoTipo;

namespace Service.Services.ProdutoTipoService
{
    public class ProdutoTipoServices : IProdutoTipoServices
    {
        private readonly IRepository<ProdutoTipoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IProdutoTipoRepository _implementacao;

        public ProdutoTipoServices(IRepository<ProdutoTipoEntity> repository, IMapper mapper, IProdutoTipoRepository implementacao)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = implementacao;
        }
        public async Task<IEnumerable<ProdutoTipoDto>> GetAll()
        {
            try
            {
                IEnumerable<ProdutoTipoEntity> entities = await _repository.SelectAsync();
                IEnumerable<ProdutoTipoDto> dtos = _mapper.Map<IEnumerable<ProdutoTipoDto>>(entities);
                dtos = dtos.OrderBy(t => t.DescricaoTipoProduto);
                return dtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoTipoDto> Get(Guid id)
        {
            try
            {
                ProdutoTipoEntity entity = await _repository.SelectAsync(id);
                ProdutoTipoDto dto = _mapper.Map<ProdutoTipoDto>(entity);

                return dto;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Task<IEnumerable<ProdutoTipoDto>> Get(string descricao)
        {
            throw new NotImplementedException();
        }
        public async Task<ProdutoTipoDto> Create(ProdutoTipoDtoCreate create)
        {
            try
            {
                ProdutoTipoModel model = _mapper.Map<ProdutoTipoModel>(create);
                ProdutoTipoEntity entity = _mapper.Map<ProdutoTipoEntity>(model);
                ProdutoTipoEntity result = await _repository.InsertAsync(entity);
                if (result != null)
                    return _mapper.Map<ProdutoTipoDto>(result);
                else
                    throw new Exception("ERRO.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoTipoDto> Update(ProdutoTipoDtoUpdate update)
        {
            try
            {
                ProdutoTipoModel model = _mapper.Map<ProdutoTipoModel>(update);
                ProdutoTipoEntity entity = _mapper.Map<ProdutoTipoEntity>(model);
                ProdutoTipoEntity result = await _repository.UpdateAsync(entity);
                if (result != null)
                    return _mapper.Map<ProdutoTipoDto>(result);
                else
                    throw new Exception("ERRO.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Desabilitar(Guid id)
        {
            try
            {
                return await _repository.DesabilitarHabilitar(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

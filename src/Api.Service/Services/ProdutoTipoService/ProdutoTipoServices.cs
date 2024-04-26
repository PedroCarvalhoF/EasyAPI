using AutoMapper;
using Domain.Dtos.ProdutoTipo;
using Domain.Entities.ProdutoTipo;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Produto;
using Domain.Interfaces.Services.ProdutoTipo;
using Domain.Models.ProdutoModels;

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
                var entities = await _repository.SelectAsync();
                var dtos = _mapper.Map<IEnumerable<ProdutoTipoDto>>(entities);
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
                var entity = await _repository.SelectAsync(id);
                var dto = _mapper.Map<ProdutoTipoDto>(entity);

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
                var model = _mapper.Map<ProdutoTipoModels>(create);
                var entity = _mapper.Map<ProdutoTipoEntity>(model);
                var result = await _repository.InsertAsync(entity);
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
                var model = _mapper.Map<ProdutoTipoModels>(update);
                var entity = _mapper.Map<ProdutoTipoEntity>(model);
                var result = await _repository.UpdateAsync(entity);
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

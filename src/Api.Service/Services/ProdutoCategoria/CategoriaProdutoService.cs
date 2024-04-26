using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Api.Domain.Models.CategoriaProdutoModels;
using AutoMapper;
using Domain.Dtos.CategoriaProdutoDtos;
using Domain.Entities.CategoriaProduto;
using Domain.Interfaces;

namespace Api.Service.Services.CategoriaProduto
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        private readonly IRepository<CategoriaProdutoEntity> _repository;
        private readonly IMapper _mapper;
        public CategoriaProdutoService(IRepository<CategoriaProdutoEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaProdutoDto> Create(CategoriaProdutoDtoCreate create)
        {
            try
            {
                var model = _mapper.Map<CategoriaProdutoModel>(create);
                var entity = _mapper.Map<CategoriaProdutoEntity>(model);
                var result = await _repository.InsertAsync(entity);
                if (result != null)
                    return _mapper.Map<CategoriaProdutoDto>(result);
                else
                    throw new Exception("ERRO.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<CategoriaProdutoDto> Update(CategoriaProdutoDtoUpdate categoriaProdutoDtoUpdate)
        {
            try
            {
                var model = _mapper.Map<CategoriaProdutoModel>(categoriaProdutoDtoUpdate);
                var entity = _mapper.Map<CategoriaProdutoEntity>(model);
                var result = await _repository.UpdateAsync(entity);
                if (result != null)
                    return _mapper.Map<CategoriaProdutoDto>(result);
                else
                    throw new Exception("ERRO.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<CategoriaProdutoDto>> Get()
        {
            try
            {
                var entities = await _repository.SelectAsync();
                var dtos = _mapper.Map<IEnumerable<CategoriaProdutoDto>>(entities);
                dtos = dtos.OrderBy(cat => cat.DescricaoCategoria);
                return dtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaProdutoDto> Get(Guid id)
        {
            try
            {
                var entity = await _repository.SelectAsync(id);
                var dto = _mapper.Map<CategoriaProdutoDto>(entity);

                return dto;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CategoriaProdutoDto>> Get(string categoria)
        {
            try
            {
                try
                {
                    throw new NotImplementedException();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DesabilitarHabilitar(Guid id)
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

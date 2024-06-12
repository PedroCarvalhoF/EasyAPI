using Api.Domain.Dtos.CategoriaProdutoDtos;
using Api.Domain.Interfaces.Services.CategoriaProduto;
using Api.Domain.Models.CategoriaProdutoModels;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.CategoriaProdutoDtos;
using Domain.Entities.CategoriaProduto;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Api.Service.Services.CategoriaProduto
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        private readonly IBaseRepository<CategoriaProdutoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly ICategoriaProdutoRepository _implementacao;
        public CategoriaProdutoService(IBaseRepository<CategoriaProdutoEntity> repository, IMapper mapper, ICategoriaProdutoRepository implementacao)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = implementacao;
        }

        public async Task<ResponseDto<List<CategoriaProdutoDto>>> GetAll()
        {
            try
            {
                var entities = await _implementacao.GetAll();
                if (entities == null || entities.Count() == 0)
                {
                    return new ResponseDto<List<CategoriaProdutoDto>>().EntitiesNull();
                }

                var dtos = _mapper.Map<List<CategoriaProdutoDto>>(entities);
                dtos = dtos.OrderBy(cat => cat.DescricaoCategoria).ToList();
                return new ResponseDto<List<CategoriaProdutoDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<CategoriaProdutoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> GetIdCategoriaProduto(Guid id )
        {
            try
            {
                var entity = await _implementacao.GetIdCategoriaProduto(id);
                if (entity == null)
                {
                    return new ResponseDto<List<CategoriaProdutoDto>>().EntitiesNull();
                }
                var dto = _mapper.Map<CategoriaProdutoDto>(entity);
                return new ResponseDto<List<CategoriaProdutoDto>>().Retorno(new List<CategoriaProdutoDto>() { dto });
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<CategoriaProdutoDto>>().Erro(ex);
            }
        }

        public async Task<ResponseDto<List<CategoriaProdutoDto>>> Create(CategoriaProdutoDtoCreate create )
        {
            try
            {
                var model = _mapper.Map<CategoriaProdutoModel>(create);
                var entity = _mapper.Map<CategoriaProdutoEntity>(model);
                var result = await _repository.InsertAsync(entity);

                if (result == null)
                {
                    return new ResponseDto<List<CategoriaProdutoDto>>().EntitiesNull();
                }

                var dto = _mapper.Map<CategoriaProdutoDto>(result);
                return new ResponseDto<List<CategoriaProdutoDto>>().Retorno(new List<CategoriaProdutoDto>() { dto });
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<CategoriaProdutoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> Update(CategoriaProdutoDtoUpdate categoriaProdutoDtoUpdate )
        {
            try
            {
                var model = _mapper.Map<CategoriaProdutoModel>(categoriaProdutoDtoUpdate);
                var entity = _mapper.Map<CategoriaProdutoEntity>(model);
                var result = await _repository.UpdateAsync(entity);

                if (result == null)
                {
                    return new ResponseDto<List<CategoriaProdutoDto>>().EntitiesNull();
                }

                var resultCreate = await _implementacao.GetIdCategoriaProduto(result.Id);

                if (resultCreate == null)
                {
                    return new ResponseDto<List<CategoriaProdutoDto>>().EntitiesNull();
                }

                return new ResponseDto<List<CategoriaProdutoDto>>().Retorno(new List<CategoriaProdutoDto>() { _mapper.Map<CategoriaProdutoDto>(resultCreate) });
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<CategoriaProdutoDto>>().Erro(ex);
            }
        }
    }
}

using Api.Domain.Dtos.CategoriaPrecoDtos;
using Api.Domain.Entities.CategoriaPreco;
using Api.Domain.Interfaces.Services.CategoriaPreco;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Api.Service.Services.CategoriaPreco
{
    public class CategoriaPrecoService : ICategoriaPrecoService
    {
        private readonly IRepository<CategoriaPrecoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly ICategoriaPrecoRepository _imprementacao;

        public CategoriaPrecoService(IRepository<CategoriaPrecoEntity> repository, IMapper mapper, ICategoriaPrecoRepository categoriaPrecoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _imprementacao = categoriaPrecoRepository;
        }
        public async Task<ResponseDto<List<CategoriaPrecoDto>>> GetAll()
        {
            var response = new ResponseDto<List<CategoriaPrecoDto>>();
            try
            {
                var entities = await _repository.SelectAsync();

                if (entities == null)
                {
                    return response.EntitiesNull();
                }

                var dtos = _mapper.Map<List<CategoriaPrecoDto>>(entities);

                return response.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CategoriaPrecoDto>>> Get(Guid id)
        {
            ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
            response.Dados = new List<CategoriaPrecoDto>();

            try
            {
                var entity = await _repository.SelectAsync(id);
                var dto = _mapper.Map<CategoriaPrecoDto>(entity);

                response.Dados.Add(dto);
                return response;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CategoriaPrecoDto>>> Create(CategoriaPrecoDtoCreate create)
        {
            ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
            response.Dados = new List<CategoriaPrecoDto>();

            try
            {
                var entity = _mapper.Map<CategoriaPrecoEntity>(create);
                var result = await _repository.InsertAsync(entity);
                var dto = _mapper.Map<CategoriaPrecoDto>(result);

                response.Dados.Add(dto);
                return response;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CategoriaPrecoDto>>> Update(CategoriaPrecoDtoUpdate update)
        {
            ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
            response.Dados = new List<CategoriaPrecoDto>();

            try
            {
                var entity = _mapper.Map<CategoriaPrecoEntity>(update);
                var result = await _repository.UpdateAsync(entity);
                var dto = _mapper.Map<CategoriaPrecoEntity>(result);

                return await Get(result.Id);
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CategoriaPrecoDto>>> Desabilitar(Guid id)
        {
            ResponseDto<List<CategoriaPrecoDto>> response = new ResponseDto<List<CategoriaPrecoDto>>();
            response.Dados = new List<CategoriaPrecoDto>();

            try
            {
                var result = await _repository.DesabilitarHabilitar(id);
                if (result)
                {
                    response.AlteracaoOk();
                    return response;
                }
                else
                {
                    response.ErroUpdate();
                    return response;
                }
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
    }
}

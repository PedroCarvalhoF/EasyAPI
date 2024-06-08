using AutoMapper;
using Domain.Dtos;
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
        private readonly IBaseRepository<ProdutoTipoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IProdutoTipoRepository _implementacao;

        public ProdutoTipoServices(IBaseRepository<ProdutoTipoEntity> repository, IMapper mapper, IProdutoTipoRepository implementacao)
        {
            _repository = repository;
            _mapper = mapper;
            _implementacao = implementacao;
        }
        public async Task<ResponseDto<List<ProdutoTipoDto>>> GetAll()
        {
            ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
            response.Dados = new List<ProdutoTipoDto>();

            try
            {
                var entities = await _repository.SelectAsync();
                var dtos = _mapper.Map<List<ProdutoTipoDto>>(entities);
                dtos = dtos.OrderBy(t => t.DescricaoTipoProduto).ToList();

                response.ConsultaOk();
                response.Dados = dtos;
                return response;

            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoTipoDto>>> Get(Guid id)
        {
            ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
            response.Dados = new List<ProdutoTipoDto>();

            try
            {
                var entity = await _repository.SelectAsync(id);
                var dto = _mapper.Map<ProdutoTipoDto>(entity);

                response.ConsultaOk();
                response.Dados.Add(dto);
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoTipoDto>>> Get(string descricao)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseDto<List<ProdutoTipoDto>>> Create(ProdutoTipoDtoCreate create)
        {
            ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
            response.Dados = new List<ProdutoTipoDto>();

            try
            {
                var model = _mapper.Map<ProdutoTipoModel>(create);
                var entity = _mapper.Map<ProdutoTipoEntity>(model);
                var result = await _repository.InsertAsync(entity);
                if (result != null)
                {

                    var resultCreate = _mapper.Map<ProdutoTipoDto>(result);

                    response.CadastroOk();
                    response.Dados.Add(resultCreate);
                    return response;
                }
                else
                {
                    response.ErroCadastro();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoTipoDto>>> Update(ProdutoTipoDtoUpdate update)
        {
            ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
            response.Dados = new List<ProdutoTipoDto>();

            try
            {
                var model = _mapper.Map<ProdutoTipoModel>(update);
                var entity = _mapper.Map<ProdutoTipoEntity>(model);
                var result = await _repository.UpdateAsync(entity);
                if (result != null)
                {
                    var dto = _mapper.Map<ProdutoTipoDto>(result);
                  
                    response.AlteracaoOk();
                    response.Dados.Add(dto);
                    return response;
                }
                else
                {
                    response.ErroCadastro();
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<ProdutoTipoDto>>> Desabilitar(Guid id)
        {
            ResponseDto<List<ProdutoTipoDto>> response = new ResponseDto<List<ProdutoTipoDto>>();
            response.Dados = new List<ProdutoTipoDto>();

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
                response.Erro(ex.Message);
                return response;
            }
        }
    }
}

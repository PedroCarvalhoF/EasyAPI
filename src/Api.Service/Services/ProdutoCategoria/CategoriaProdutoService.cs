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

        public async Task<ResponseDto<List<CategoriaProdutoDto>>> Get()
        {
            ResponseDto<List<CategoriaProdutoDto>> response = new ResponseDto<List<CategoriaProdutoDto>>();
            response.Dados = new List<CategoriaProdutoDto>();
            try
            {
                var entities = await _repository.SelectAsync();
                if (entities == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Não foi possível realizar consulta";
                    return response;
                }

                var dtos = _mapper.Map<List<CategoriaProdutoDto>>(entities);
                dtos = dtos.OrderBy(cat => cat.DescricaoCategoria).ToList();
                response.Dados = dtos;
                response.Mensagem = "Consulta realizada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> Get(Guid id)
        {
            ResponseDto<List<CategoriaProdutoDto>> response = new ResponseDto<List<CategoriaProdutoDto>>();
            response.Dados = new List<CategoriaProdutoDto>();
            try
            {
                var entity = await _repository.SelectAsync(id);
                if (entity == null)
                {
                    response.Status = true;
                    response.Mensagem = $"Id não localizado: {id}";
                    return response;
                }


                var dto = _mapper.Map<CategoriaProdutoDto>(entity);
                response.Dados.Add(dto);
                response.Mensagem = "Categoria localizada com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> Get(string categoria)
        {
            ResponseDto<List<CategoriaProdutoDto>> response = new ResponseDto<List<CategoriaProdutoDto>>();
            response.Dados = new List<CategoriaProdutoDto>();
            try
            {
                IEnumerable<CategoriaProdutoEntity> entities = await _implementacao.Get(categoria);
                if (entities == null)
                {
                    response.Status = false;
                    response.Mensagem = "Não foi possível realizar consulta.";
                    return response;
                }

                var dtos = _mapper.Map<List<CategoriaProdutoDto>>(entities);

                response.Dados = dtos;
                response.Mensagem = "Categorias localizadas com sucesso";
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> Create(CategoriaProdutoDtoCreate create)
        {
            ResponseDto<List<CategoriaProdutoDto>> response = new ResponseDto<List<CategoriaProdutoDto>>();
            response.Dados = new List<CategoriaProdutoDto>();
            try
            {
                var model = _mapper.Map<CategoriaProdutoModel>(create);
                var entity = _mapper.Map<CategoriaProdutoEntity>(model);
                var result = await _repository.InsertAsync(entity);

                if (result == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Não foi possível cadastrar categoria do produto";
                    return response;
                }

                var dto = _mapper.Map<CategoriaProdutoDto>(result);
                response.Dados.Add(dto);
                response.Status = true;
                response.Mensagem = $"Categoria criada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> CreateLote(IEnumerable<CategoriaProdutoDtoCreate> lista)
        {

            try
            {
                var model = _mapper.Map<IEnumerable<CategoriaProdutoModel>>(lista);
                var entity = _mapper.Map<IEnumerable<CategoriaProdutoEntity>>(model);
                var result = await _repository.InsertArrayAsync(entity);

                if (result == 0)
                {
                    return new ResponseDto<List<CategoriaProdutoDto>>().Erro("Não foi possível cadastrar o lote de categorias");
                }
                return new ResponseDto<List<CategoriaProdutoDto>>().CadastroOk("Cadastro do lote efetuado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<CategoriaProdutoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> Update(CategoriaProdutoDtoUpdate categoriaProdutoDtoUpdate)
        {
            ResponseDto<List<CategoriaProdutoDto>> response = new ResponseDto<List<CategoriaProdutoDto>>();
            response.Dados = new List<CategoriaProdutoDto>();

            try
            {
                var model = _mapper.Map<CategoriaProdutoModel>(categoriaProdutoDtoUpdate);
                var entity = _mapper.Map<CategoriaProdutoEntity>(model);
                var result = await _repository.UpdateAsync(entity);

                if (result == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Não foi possível alterar categoria do produto";
                    return response;
                }

                var resultCreate = await _repository.SelectAsync(result.Id);

                if (resultCreate == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Não foi possível alterar categoria do produto";
                    return response;
                }

                var resultDto = _mapper.Map<CategoriaProdutoDto>(resultCreate);

                response.Dados.Add(resultDto);
                response.Mensagem = "Categoria alterada com sucesso!";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseDto<List<CategoriaProdutoDto>>> DesabilitarHabilitar(Guid id)
        {
            ResponseDto<List<CategoriaProdutoDto>> response = new ResponseDto<List<CategoriaProdutoDto>>();
            response.Dados = new List<CategoriaProdutoDto>();
            try
            {
                var result = await _repository.DesabilitarHabilitar(id);
                if (result)
                {
                    response.Status = true;
                    response.Mensagem = "Categoria desabilitada";
                    return response;
                }
                else
                {
                    response.Status = true;
                    response.Mensagem = "Não foi possivel desabilitadar ";
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                response.Status = false;
                return response;
            }
        }


    }
}

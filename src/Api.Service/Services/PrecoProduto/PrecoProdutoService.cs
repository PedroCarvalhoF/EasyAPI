using Api.Domain.Dtos.PrecoProdutoDtos;
using Api.Domain.Entities.PrecoProduto;
using Api.Domain.Interfaces.Services.PrecoProdutoService;
using Api.Domain.Models.PrecoProdutoModels;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Api.Service.Services.PrecoProduto
{
    public class PrecoProdutoService : IPrecoProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<PrecoProdutoEntity> _repository;
        private readonly IPrecoProdutoRepository _implementacao;

        public PrecoProdutoService(IMapper mapper, IBaseRepository<PrecoProdutoEntity> repository, IPrecoProdutoRepository precoProdutoRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _implementacao = precoProdutoRepository;
        }
        public async Task<ResponseDto<List<PrecoProdutoDto>>> GetAll()
        {
            var response = new ResponseDto<List<PrecoProdutoDto>>();
            try
            {
                var entities = await _implementacao.GetAll();
                var dtos = _mapper.Map<List<PrecoProdutoDto>>(entities);
                return response.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return response.Erro(ex.Message);
            }
        }
        public async Task<ResponseDto<List<PrecoProdutoDto>>> Get(Guid id)
        {
            var response = new ResponseDto<List<PrecoProdutoDto>>();
            response.Dados = new List<PrecoProdutoDto>();

            try
            {
                var entity = await _implementacao.Get(id);
                var dto = _mapper.Map<PrecoProdutoDto>(entity);

                response.Dados.Add(dto);
                response.ConsultaOk();
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }

        public async Task<ResponseDto<List<PrecoProdutoDto>>> GetIdProduto(Guid id)
        {
            var response = new ResponseDto<List<PrecoProdutoDto>>();
            response.Dados = new List<PrecoProdutoDto>();

            try
            {
                var entities = await _implementacao.GetProdutoId(id);
                var dtos = _mapper.Map<List<PrecoProdutoDto>>(entities);

                response.Dados = dtos;
                response.ConsultaOk();
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }
        public async Task<ResponseDto<List<PrecoProdutoDto>>> GetIdCategoriaPreco(Guid id)
        {
            var response = new ResponseDto<List<PrecoProdutoDto>>();
            response.Dados = new List<PrecoProdutoDto>();

            try
            {
                var entities = await _implementacao.GetCategoriaPrecoId(id);
                var dtos = _mapper.Map<List<PrecoProdutoDto>>(entities);

                response.Dados = dtos;
                response.ConsultaOk();
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }

        public async Task<ResponseDto<List<PrecoProdutoDto>>> CreateUpdate(PrecoProdutoDtoCreate createUpdate)
        {
            var response = new ResponseDto<List<PrecoProdutoDto>>();
            response.Dados = new List<PrecoProdutoDto>();

            try
            {
                var model = _mapper.Map<PrecoProdutoModel>(createUpdate);
                var entidade = _mapper.Map<PrecoProdutoEntity>(model);
                var precoExists = await _implementacao.PrecoExists(model.ProdutoEntityId, model.CategoriaPrecoEntityId);

                if (precoExists is null)
                {
                    //cadastrar                    
                    var result = await _repository.InsertAsync(entidade);
                    var responseCreateResult = await Get(result.Id);
                    if (responseCreateResult.Status)
                    {
                        responseCreateResult.Mensagem = "Preço cadastrado com sucesso!";
                    }

                    return responseCreateResult;
                }
                else
                {
                    //alterar
                    entidade.Id = precoExists.Id;
                    entidade.Habilitado = true;
                    var result = await _repository.UpdateAsync(entidade);
                    var responseUpdateResult = await Get(result.Id);
                    if (responseUpdateResult.Status)
                    {
                        responseUpdateResult.Mensagem = "Preço alterado com sucesso!";
                    }

                    return responseUpdateResult;
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
using AutoMapper;
using Domain.Dtos;
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
        public async Task<ResponseDto<List<ProdutoDto>>> Get()
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                var entities = await _implementacao.Get();
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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

        public async Task<ResponseDto<List<ProdutoDto>>> Get(Guid id)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                var entities = await _implementacao.Get(id);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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

        public async Task<ResponseDto<List<ProdutoDto>>> Get(string nomeProduto)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                var entities = await _implementacao.Get(nomeProduto);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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

        public async Task<ResponseDto<List<ProdutoDto>>> GetCategoria(Guid categoriaId)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.GetCategoria(categoriaId);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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

        public async Task<ResponseDto<List<ProdutoDto>>> GetCodigo(string codigoPersonalizado)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                ProdutoEntity entities = await _implementacao.GetCodigo(codigoPersonalizado);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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

        public async Task<ResponseDto<List<ProdutoDto>>> GetHabilitadoNaoHabilitado(bool habilitado)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.GetHabilitadoNaoHabilitado(habilitado);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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

        public async Task<ResponseDto<List<ProdutoDto>>> GetMedida(Guid categoriaId)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                IEnumerable<ProdutoEntity> entities = await _implementacao.GetMedida(categoriaId);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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

        public async Task<ResponseDto<List<ProdutoDto>>> GetProdutoTipo(Guid categoriaId)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                var entities = await _implementacao.GetProdutoTipo(categoriaId);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);

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
        public async Task<ResponseDto<List<ProdutoDto>>> Cadastrar(ProdutoDtoCreate produtoDtoCreate)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                var model = _mapper.Map<ProdutoModel>(produtoDtoCreate);
                var entity = _mapper.Map<ProdutoEntity>(model);
                var result = await _repository.InsertAsync(entity);

                var dto = _mapper.Map<ProdutoDto>(result);

                response.CadastroOk();
                response.Dados.Add(dto);
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }

        public async Task<ResponseDto<List<ProdutoDto>>> Alterar(ProdutoDtoUpdate produtoDtoUpdate)
        {
            ResponseDto<List<ProdutoDto>> response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                var model = _mapper.Map<ProdutoModel>(produtoDtoUpdate);

                model.Update();

                var entity = _mapper.Map<ProdutoEntity>(model);
                var result = await _repository.UpdateAsync(entity);


                var dto = _mapper.Map<ProdutoDto>(result);

                response.AlteracaoOk();
                response.Dados.Add(dto);
                return response;
            }
            catch (Exception ex)
            {
                response.Erro(ex.Message);
                return response;
            }
        }

    }
}

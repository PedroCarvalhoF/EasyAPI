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
        private readonly IBaseRepository<ProdutoEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _implementacao;
        public ProdutoService(IBaseRepository<ProdutoEntity> repository, IMapper mapper, IProdutoRepository produtoRepository)
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
                var dto = _mapper.Map<ProdutoDto>(entities);

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
        public async Task<ResponseDto<List<ProdutoDto>>> GetProdutosByPdvAsync(Guid idPdv)
        {
            try
            {
                var entities = await _implementacao.GetProdutosByPdvAsync(idPdv);
                var dtos = _mapper.Map<List<ProdutoDto>>(entities);
                return new ResponseDto<List<ProdutoDto>>().Retorno(dtos);
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ProdutoDto>>().Erro(ex);
            }
        }
        //MÉTODOS
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
        public async Task<ResponseDto<List<ProdutoDto>>> CreateArray(IEnumerable<ProdutoDtoCreate> arrayCreate)
        {
            try
            {
                var model = _mapper.Map<IEnumerable<ProdutoModel>>(arrayCreate);
                var entity = _mapper.Map<IEnumerable<ProdutoEntity>>(model);
                var result = await _repository.InsertArrayAsync(entity);
                if (result == 0)
                {
                    return new ResponseDto<List<ProdutoDto>>().Erro("Não foi possível cadastra lote de produtos");
                }

                return new ResponseDto<List<ProdutoDto>>().CadastroOk("Lote de produtos cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<ProdutoDto>>().Erro(ex);
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

        public async Task<ResponseDto<List<ProdutoDto>>> Desabilitar(Guid id)
        {
            var response = new ResponseDto<List<ProdutoDto>>();
            response.Dados = new List<ProdutoDto>();

            try
            {
                var entity = await _repository.SelectAsync(id);

                if (entity == null)
                {
                    response.Erro("Produto não localizado");
                    return response;
                }

                if (!entity.Habilitado)
                {
                    response.Erro("Produto já está desabilitado");
                    return response;
                }

                var model = _mapper.Map<ProdutoModel>(entity);
                model.Desabilitar();
                entity = _mapper.Map<ProdutoEntity>(model);

                var resultUpdate = await _repository.UpdateAsync(entity);

                if (resultUpdate == null)
                {
                    response.Erro("Não foi possível realizar alteração");
                    return response;
                }

                var confirmaUpdate = await Get(resultUpdate.Id);
                if (confirmaUpdate.Status)
                    if (confirmaUpdate!.Dados!.FirstOrDefault()!.Habilitado == false)
                    {
                        confirmaUpdate.Mensagem = "Produto desabilitado";
                        return confirmaUpdate;
                    }

                response.Erro("Não foi possível realizar alteração");
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

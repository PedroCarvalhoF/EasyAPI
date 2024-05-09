using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Entities.Pedido;
using Api.Domain.Interfaces.Services.Pedido;
using Api.Domain.Models.PedidoModels;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Pedidos;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Pedido;
using System.Linq.Expressions;

namespace Api.Service.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<PedidoEntity> _repository;
        private readonly IPedidoRepository _implementacao;
        public PedidoService(IMapper mapper,
                             IRepository<PedidoEntity> repository,
                             IPedidoRepository implementacao)
        {
            _mapper = mapper;
            _repository = repository;
            _implementacao = implementacao;
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAll()
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();
            try
            {
                var result = await _implementacao.GetAll();

                if (result == null)
                {
                    responseDto.Erro();
                    return responseDto;
                }

                var dtos = _mapper.Map<List<PedidoDto>>(result);

                responseDto.Dados = dtos;

                responseDto.ConsultaOk();

                return responseDto;
            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> Get(Guid idPedido)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();
            try
            {
                PedidoEntity result = await _implementacao.Get(idPedido);

                if (result == null)
                {
                    responseDto.Erro();
                    return responseDto;
                }

                var pedidoDto = _mapper.Map<PedidoDto>(result);

                responseDto.Dados.Add(pedidoDto);

                responseDto.ConsultaOk();

                return responseDto;
            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAll(Guid idPdv)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();

            try
            {
                var entities = await _implementacao.GetAll(idPdv);

                if (entities == null)
                {
                    responseDto.Status = false;
                    responseDto.Mensagem = $"Erro.Não foi possível consultar";
                    return responseDto;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);
                responseDto.Dados = pedidoDto;

                responseDto.ConsultaOk(pedidoDto.Count);

                return responseDto;

            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllByCategoriaPreco(Guid idPdv, Guid idCategoriaPreco)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();

            try
            {
                var entities = await _implementacao.GetAllByCategoriaPreco(idPdv, idCategoriaPreco);

                if (entities == null)
                {
                    responseDto.Status = false;
                    responseDto.Mensagem = $"Erro.Não foi possível consultar";
                    return responseDto;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);

                responseDto.Status = true;
                responseDto.Dados = pedidoDto;
                responseDto.Mensagem = $"Consulta realizada com sucesso. Registros: {pedidoDto.Count}";

                return responseDto;
            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllBySituacao(Guid idPdv, Guid idSituacao)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();

            try
            {
                var entities = await _implementacao.GetAllBySituacao(idPdv, idSituacao);

                if (entities == null)
                {
                    responseDto.Status = false;
                    responseDto.Mensagem = $"Erro.Não foi possível consultar";
                    return responseDto;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);

                responseDto.Status = true;
                responseDto.Dados = pedidoDto;
                responseDto.Mensagem = $"Consulta realizada com sucesso. Registros: {pedidoDto.Count}";

                return responseDto;

            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllByUser(Guid idPdv, Guid idUserCreatePedido)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();

            try
            {
                var entities = await _implementacao.GetAllByUser(idPdv, idUserCreatePedido);

                if (entities == null)
                {
                    responseDto.Status = false;
                    responseDto.Mensagem = $"Erro.Não foi possível consultar";
                    return responseDto;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);

                responseDto.Status = true;
                responseDto.Dados = pedidoDto;
                responseDto.Mensagem = $"Consulta realizada com sucesso. Registros: {pedidoDto.Count}";

                return responseDto;

            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GerarPedido(PedidoDtoCreate pedidoDtoCreate)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();

            try
            {
                var model = _mapper.Map<PedidoModel>(pedidoDtoCreate);

                model.GerarPedido();

                var entity = _mapper.Map<PedidoEntity>(model);
                var result = await _repository.InsertAsync(entity);

                if (result == null)
                {
                    responseDto.Status = false;
                    responseDto.Mensagem = $"Erro.Não foi possível criar pedido";
                    return responseDto;
                }

                var pedidoCriadoDto = await Get(result.Id);

                pedidoCriadoDto.CadastroOk("Pedido", "Pedido gerado com sucesso.");


                return pedidoCriadoDto;
            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> EncerrarPedido(Guid idPedido)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();

            try
            {
                var pedidoSelecionado = await _repository.SelectAsync(idPedido);

                var model = _mapper.Map<PedidoModel>(pedidoSelecionado);

                model.EncerrarPedido();

                var entity = _mapper.Map<PedidoEntity>(model);
                var resultUpdate = await _repository.UpdateAsync(entity);

                if (resultUpdate == null)
                {
                    responseDto.Status = false;
                    responseDto.Mensagem = $"Erro.Não foi possível encerrar o pedido";
                    return responseDto;
                }

                responseDto.Status = true;
                responseDto.Mensagem = $"Pedido encerrado com sucesso. {DateTime.Now}";

                return responseDto;

            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> CancelarPedido(PedidoDtoCancelar cancelamentoPedido)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();

            try
            {
                var pedidoSelecionado = await _repository.SelectAsync(cancelamentoPedido.IdPedido);

                if (pedidoSelecionado == null)
                {
                    responseDto.ErroConsulta();
                    return responseDto;
                }

                var model = _mapper.Map<PedidoModel>(pedidoSelecionado);

                model.CancelarPedido(cancelamentoPedido.MotivoCancelamento);

                var entity = _mapper.Map<PedidoEntity>(model);
                var resultUpdate = await _repository.UpdateAsync(entity);

                if (resultUpdate == null)
                {
                    responseDto.ErroUpdate();
                    return responseDto;
                }

                responseDto.AlteracaoOk("Pedido", $"cancelado com sucesso {DateTime.Now}");

                return responseDto;

            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAll(Expression<Func<PedidoDto, bool>> funcao, bool inlude = true)
        {
            ResponseDto<List<PedidoDto>> responseDto = new ResponseDto<List<PedidoDto>>();
            responseDto.Dados = new List<PedidoDto>();
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                responseDto.Status = false;
                responseDto.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return responseDto;
            }
        }


    }
}
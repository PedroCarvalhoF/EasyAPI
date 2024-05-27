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

        //CONSULTAS GENERICAS
        public async Task<ResponseDto<List<PedidoDto>>> GetAll()
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var result = await _implementacao.GetAll();

                if (result == null)
                {
                    response.Erro();
                    return response;
                }

                var dtos = _mapper.Map<List<PedidoDto>>(result);

                response.Dados = dtos;

                response.ConsultaOk();

                return response;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> Get(Guid idPedido)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                PedidoEntity result = await _implementacao.Get(idPedido);

                if (result == null)
                {
                    response.Erro();
                    return response;
                }

                var pedidoDto = _mapper.Map<PedidoDto>(result);

                response.Dados = new List<PedidoDto>() { pedidoDto };
                response.ConsultaOk();

                return response;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAll(Expression<Func<PedidoDto, bool>> funcao, bool inlude = true)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return response;
            }
        }

        //CONSULTAS POR PDVS
        public async Task<ResponseDto<List<PedidoDto>>> GetAll(Guid idPdv)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var entities = await _implementacao.GetAll(idPdv);

                if (entities == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Erro.Não foi possível consultar";
                    return response;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);
                response.Dados = pedidoDto;

                response.ConsultaOk(pedidoDto.Count);

                return response;

            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllByPdvByNumeroPedidoContains(Guid idPdv, string numeroPedido)
        {
            try
            {
                var entities = await _implementacao.GetAllByPdvByNumeroPedidoContains(idPdv, numeroPedido);

                if (entities == null)
                {
                    return new ResponseDto<List<PedidoDto>>().EntitiesNull();
                }

                return new ResponseDto<List<PedidoDto>>().Retorno(_mapper.Map<List<PedidoDto>>(entities));
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<PedidoDto>>().Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllByCategoriaPreco(Guid idPdv, Guid idCategoriaPreco)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var entities = await _implementacao.GetAllByCategoriaPreco(idPdv, idCategoriaPreco);

                if (entities == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Erro.Não foi possível consultar";
                    return response;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);

                response.Status = true;
                response.Dados = pedidoDto;
                response.Mensagem = $"Consulta realizada com sucesso. Registros: {pedidoDto.Count}";

                return response;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllBySituacao(Guid idPdv, Guid idSituacao)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var entities = await _implementacao.GetAllBySituacao(idPdv, idSituacao);

                if (entities == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Erro.Não foi possível consultar";
                    return response;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);

                response.Status = true;
                response.Dados = pedidoDto;
                response.Mensagem = $"Consulta realizada com sucesso. Registros: {pedidoDto.Count}";

                return response;

            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllByUser(Guid idPdv, Guid idUserCreatePedido)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var entities = await _implementacao.GetAllByUser(idPdv, idUserCreatePedido);

                if (entities == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Erro.Não foi possível consultar";
                    return response;
                }

                var pedidoDto = _mapper.Map<List<PedidoDto>>(entities);

                response.Status = true;
                response.Dados = pedidoDto;
                response.Mensagem = $"Consulta realizada com sucesso. Registros: {pedidoDto.Count}";

                return response;

            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllByPagamento(Guid idPdv, Guid idFormaPagamento)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var entities = await _implementacao.GetAllByPagamento(idPdv, idFormaPagamento);

                if (entities == null)
                {
                    return response.EntitiesNull();
                }

                return response.Retorno(_mapper.Map<List<PedidoDto>>(entities));
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> GetAllByPdvByProdutoAsync(Guid idPdv, Guid idProduto)
        {
            try
            {
                var entities = await _implementacao.GetAllByPdvByProdutoAsync(idPdv, idProduto);

                if (entities == null)
                {
                    return new ResponseDto<List<PedidoDto>>().EntitiesNull();
                }

                return new ResponseDto<List<PedidoDto>>().Retorno(_mapper.Map<List<PedidoDto>>(entities));
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<PedidoDto>>().Erro(ex);
            }
        }

        //MÉTODOS
        public async Task<ResponseDto<List<PedidoDto>>> GerarPedido(PedidoDtoCreate pedidoDtoCreate)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var model = _mapper.Map<PedidoModel>(pedidoDtoCreate);

                model.GerarPedido();

                var entity = _mapper.Map<PedidoEntity>(model);
                var result = await _repository.InsertAsync(entity);

                if (result == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Erro.Não foi possível criar pedido";
                    return response;
                }

                var pedidoCriadoDto = await Get(result.Id);

                pedidoCriadoDto.CadastroOk("Pedido", "Pedido gerado com sucesso.");


                return pedidoCriadoDto;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> AtualizarValorPedido(Guid idPedido)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var entitie = await _implementacao.Get(idPedido);
                if (entitie == null)
                {
                    return response.EntitiesNull();
                }

                var model = _mapper.Map<PedidoModel>(entitie);
                model.AtualizarValorPedido();
                var entityUpdate = _mapper.Map<PedidoEntity>(model);

                var resultUpdate = await _repository.UpdateAsync(entityUpdate);
                if (resultUpdate == null)
                {
                    return response.ErroUpdate("Não foi possível realizar alteração.");
                }


                var updateVerifica = await Get(idPedido);

                if (updateVerifica.Status)
                {
                    return updateVerifica.UpdateOk();
                }

                return response;

            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> EncerrarPedido(Guid idPedido)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var pedidoSelecionado = await _repository.SelectAsync(idPedido);

                var model = _mapper.Map<PedidoModel>(pedidoSelecionado);

                model.EncerrarPedido();

                var entity = _mapper.Map<PedidoEntity>(model);
                var resultUpdate = await _repository.UpdateAsync(entity);

                if (resultUpdate == null)
                {
                    response.Status = false;
                    response.Mensagem = $"Erro.Não foi possível encerrar o pedido";
                    return response;
                }

                response.Status = true;
                response.Mensagem = $"Pedido encerrado com sucesso. {DateTime.Now}";

                return response;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"Erro.Detalhes: {ex.Message}";
                return response;
            }
        }
        public async Task<ResponseDto<List<PedidoDto>>> CancelarPedido(PedidoDtoCancelar cancelamentoPedido)
        {
            var response = new ResponseDto<List<PedidoDto>>();

            try
            {
                var pedidoSelecionado = await _repository.SelectAsync(cancelamentoPedido.IdPedido);

                if (pedidoSelecionado == null)
                {
                    response.ErroConsulta();
                    return response;
                }

                var model = _mapper.Map<PedidoModel>(pedidoSelecionado);

                model.CancelarPedido(cancelamentoPedido.MotivoCancelamento);

                var entity = _mapper.Map<PedidoEntity>(model);
                var resultUpdate = await _repository.UpdateAsync(entity);

                if (resultUpdate == null)
                {
                    response.ErroUpdate();
                    return response;
                }

                response.AlteracaoOk("Pedido", $"cancelado com sucesso {DateTime.Now}");

                return response;

            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
    }
}
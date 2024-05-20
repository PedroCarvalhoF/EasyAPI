using Api.Domain.Entities.Pedido;
using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Entities.FormaPagamento;
using Domain.Entities.PagamentoPedido;
using Domain.Interfaces;
using Domain.Interfaces.Repository.PedidoPagamento;
using Domain.Interfaces.Services.PagamentoPedido;
using Domain.Models.PagamentoPedidoModels;

namespace Service.Services.PagamentoPedidoServices
{
    public class PagamentoPedidoService : IPagamentoPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IPagamentoPedidoRepository _implementacao;
        private readonly IRepository<PagamentoPedidoEntity> _repository;
        private readonly IRepository<PedidoEntity> _pedidoRepository;
        private readonly IRepository<FormaPagamentoEntity> _formaPgmtRespository;
        public PagamentoPedidoService(IMapper mapper,
                                      IPagamentoPedidoRepository pagamentoPedidoRepository,
                                      IRepository<PagamentoPedidoEntity> repository,
                                      IRepository<PedidoEntity> pedidoRepository,
                                      IRepository<FormaPagamentoEntity> formaPgmtRepository)
        {
            _mapper = mapper;
            _implementacao = pagamentoPedidoRepository;
            _repository = repository;
            _pedidoRepository = pedidoRepository;
            _formaPgmtRespository = formaPgmtRepository;
        }

        public async Task<ResponseDto<List<PagamentoPedidoDto>>> GetAll()
        {
            var response = new ResponseDto<List<PagamentoPedidoDto>>();

            try
            {
                var entities = await _implementacao!.GetAll();
                if (entities == null)
                {
                    return response.EntitiesNull();
                }

                var dtos = _mapper.Map<List<PagamentoPedidoDto>>(entities);
                return response.Retorno(dtos);
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PagamentoPedidoDto>>> Get(Guid idPagamento)
        {
            var response = new ResponseDto<List<PagamentoPedidoDto>>();

            try
            {
                var entity = await _implementacao!.Get(idPagamento);
                if (entity == null)
                {
                    return response.EntitiesNull();
                }

                var dto = _mapper.Map<PagamentoPedidoDto>(entity);
                return response.Retorno(new List<PagamentoPedidoDto>() { dto });
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PagamentoPedidoDto>>> GetByIdPedido(Guid idPedido)
        {
            var response = new ResponseDto<List<PagamentoPedidoDto>>();

            try
            {
                var entities = await _implementacao!.GetByIdPedido(idPedido);
                if (entities == null || entities.Count() == 0)
                {
                    return response.EntitiesNull();
                }

                var dto = _mapper.Map<List<PagamentoPedidoDto>>(entities);
                return response.Retorno(dto);
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PagamentoPedidoDto>>> InserirPagamentoPedido(PagamentoPedidoDtoCreate pgPedido)
        {
            var response = new ResponseDto<List<PagamentoPedidoDto>>();

            try
            {
                var model = _mapper.Map<PagamentoPedidoModel>(pgPedido);

                var pedidoExists = await _pedidoRepository.SelectAsync(model.PedidoEntityId);
                if (pedidoExists == null)
                {
                    return response.Erro("Pedido não localizado.");
                }

                if (pedidoExists.SituacaoPedidoEntityId == Guid.Parse("11b17cc5-c8b1-48f9-b9fd-886339441328"))
                {
                    return response.Erro("Não é possivel inserir forma de pagamento em um pedido cancelado.");
                }

                if (!pedidoExists.Habilitado)
                {
                    return response.Erro("Não é possivel inserir pagamento em um pedido finalizado.");
                }


                var formaPagamentoExists = await _formaPgmtRespository.SelectAsync(model.FormaPagamentoEntityId);
                if (formaPagamentoExists == null)
                {
                    return response.Erro("Forma de pagamento não localizado.");
                }

                if (!formaPagamentoExists.Habilitado)
                    return response.Erro("Forma de pagamento informada não esta habilitada.");


                var pagamentoEntity = _mapper.Map<PagamentoPedidoEntity>(model);

                var pagamentoEntityResult = await _repository.InsertAsync(pagamentoEntity);
                if (pagamentoEntityResult == null)
                {
                    return response.Erro("Não foi possível inserir pagamento do pedido");
                }

                var result = await Get(pagamentoEntityResult.Id);

                if (!result.Status)
                {
                    return response.Erro("Não foi possível inserir pagamento do pedido");
                }

                result.Mensagem = "Pagamento inserido com sucesso.";

                return result;
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
        public async Task<ResponseDto<List<PagamentoPedidoDto>>> RemoverPagamentoPedido(Guid idPagamento)
        {
            var response = new ResponseDto<List<PagamentoPedidoDto>>();

            try
            {
                var pagamento = await _repository.SelectAsync(idPagamento);


                var pedido = await _pedidoRepository.SelectAsync(pagamento.PedidoEntityId);
                if (pedido == null)
                {
                    return response.Erro("Pedido não localizado.");
                }

                if (pedido.SituacaoPedidoEntityId == Guid.Parse("11b17cc5-c8b1-48f9-b9fd-886339441328"))
                {
                    return response.Erro("Não é possivel remover forma de pagamento em um pedido cancelado.");
                }

                if (!pedido.Habilitado)
                {
                    return response.Erro("Não é possivel inserir pagamento em um pedido finalizado.");
                }


                var formaPagamentoExists = await _formaPgmtRespository.SelectAsync(pagamento.FormaPagamentoEntityId);
                if (formaPagamentoExists == null)
                {
                    return response.Erro("Forma de pagamento não localizado.");
                }

                if (!formaPagamentoExists.Habilitado)
                    return response.Erro("Forma de pagamento não está habilitada.Não é possível manipular");



                var result = await _repository.DeleteAsync(pagamento.Id);
                if (result)
                {
                    return response.DeleteOK("Pagamento deletado com sucesso!");
                }

                return response.ErroUpdate();
            }
            catch (Exception ex)
            {
                return response.Erro(ex);
            }
        }
    }
}
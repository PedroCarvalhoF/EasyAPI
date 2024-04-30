using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Interfaces.Services.Pedido;
using AutoMapper;
using Domain.Dtos.PagamentoPedidoDtos;
using Domain.Entities.PagamentoPedido;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services.PagamentoPedido;
using Domain.Models.PagamentoPedidoModels;

namespace Service.Services.PagamentoPedidoServices
{
    public class PagamentoPedidoService : IPagamentoPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IPagamentoPedidoRepository _pagamentoPedidoRepository;
        private readonly IRepository<PagamentoPedidoEntity> _repository;
        private readonly IPedidoService _pedidoService;

        public PagamentoPedidoService(IMapper mapper,
                                      IPagamentoPedidoRepository pagamentoPedidoRepository,
                                      IRepository<PagamentoPedidoEntity> repository,
                                      IPedidoService pedidoService)
        {
            _mapper = mapper;
            _pagamentoPedidoRepository = pagamentoPedidoRepository;
            _repository = repository;
            _pedidoService = pedidoService;
        }

        public async Task<IEnumerable<PagamentoPedidoDto>> ConsultarPagamentosPedidoByIdPedido(Guid idPedido)
        {
            try
            {
                IEnumerable<PagamentoPedidoEntity> entities = await _pagamentoPedidoRepository.ConsultarPagamentosPedidoByIdPedido(idPedido);
                IEnumerable<PagamentoPedidoDto> dtos = _mapper.Map<IEnumerable<PagamentoPedidoDto>>(entities);
                return dtos;
            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> InseririPagamentoPedido(PagamentoPedidoDtoCreate pagamentoPedidoDto)
        {
            try
            {
                PagamentoPedidoModel model = _mapper.Map<PagamentoPedidoModel>(pagamentoPedidoDto);
                PagamentoPedidoEntity entity = _mapper.Map<PagamentoPedidoEntity>(model);
                PagamentoPedidoEntity resultPagamento = await _repository.InsertAsync(entity);
                IEnumerable<PedidoDto> pedido = await _pedidoService.GetByIdPedido(resultPagamento.PedidoEntityId, true);

                return pedido.FirstOrDefault();

            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> InseririPagamentoPedidoLote(IEnumerable<PagamentoPedidoDtoCreate> pgts)
        {
            try
            {
                IEnumerable<PagamentoPedidoModel> model = _mapper.Map<IEnumerable<PagamentoPedidoModel>>(pgts);
                IEnumerable<PagamentoPedidoEntity> entities = _mapper.Map<IEnumerable<PagamentoPedidoEntity>>(model);
                IEnumerable<PagamentoPedidoEntity> resultLoto = await _repository.InsertAsync(entities);

                if (pgts.Count() == resultLoto.Count())
                    return true;
                else
                    return false;


            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PagamentoPedidoDto>> RemoverPagamentosPedidoByIdPagamento(Guid idPagamento)
        {
            try
            {
                PagamentoPedidoEntity pagamentoEntity = await _repository.SelectAsync(idPagamento);
                bool resultDelete = await _repository.DeleteAsync(idPagamento);

                IEnumerable<PagamentoPedidoDto> pagamentos = await ConsultarPagamentosPedidoByIdPedido(pagamentoEntity.PedidoEntityId);

                return pagamentos;
            }
            catch (ModelsExceptions ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoverPagamentosPedidoByIdPedido(Guid idPedido)
        {
            try
            {
                IEnumerable<PagamentoPedidoDto> pagamentos = await ConsultarPagamentosPedidoByIdPedido(idPedido);
                int qtd_pagamentos = pagamentos.Count();
                List<Guid> ids = new List<Guid>();
                foreach (PagamentoPedidoDto pagamento in pagamentos)
                {
                    ids.Add(pagamento.Id);
                }

                int result = await _repository.DeleteAsync(ids);

                if (qtd_pagamentos == result)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

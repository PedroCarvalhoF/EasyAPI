using Api.Domain.Dtos.PedidoDtos;
using Api.Domain.Entities.Pedido;
using Api.Domain.Entities.PontoVenda;
using Api.Domain.Interfaces.Services.Pedido;
using Api.Domain.Models.PedidoModels;
using AutoMapper;
using Domain.Dtos.PedidoDtos;
using Domain.Entities.ItensPedido;
using Domain.Enuns;
using Domain.ExceptionsPersonalizadas;
using Domain.Interfaces;
using Domain.Repository;

namespace Api.Service.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly IRepository<PedidoEntity> _repository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IRepository<PontoVendaEntity> _pontoVendaRepository;
        private readonly IRepository<ItemPedidoEntity> _repositoryItemPedidoEntity;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IMapper _mapper;


        public PedidoService(IRepository<PedidoEntity> repository, IMapper mapper, IPedidoRepository pedidoRepository, IRepository<PontoVendaEntity> pontoVendaRepository, IRepository<ItemPedidoEntity> _repositoryItemPedidoEntity, IItemPedidoRepository itemPedidoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
            _pontoVendaRepository = pontoVendaRepository;
            this._repositoryItemPedidoEntity = _repositoryItemPedidoEntity;
            this._itemPedidoRepository = itemPedidoRepository;
        }


        #region Gerar/Encerrar/Cancelar --PEDIDO  
        public async Task<PedidoDto> GerarPedido(PedidoDtoCreate pedidoDtoCreate)
        {
            try
            {

                PontoVendaEntity pdv = await _pontoVendaRepository.SelectAsync(pedidoDtoCreate.PontoVendaEntityId);
                if (pdv.AbertoFechado.Equals(false))
                    throw new ModelsExceptions("Não é possível gerar pedido, com ponto de venda encerrado.");

                PedidoModels model = _mapper.Map<PedidoModels>(pedidoDtoCreate);

                PedidoEntity entity = _mapper.Map<PedidoEntity>(model);
                PedidoEntity result = await _repository.InsertAsync(entity);
                //var pedido = await _pedidoRepository.SelectAsync(p => p.Id == result.Id, true);

                IEnumerable<PedidoEntity> pedidos_pdv = await _pedidoRepository.SelectAsync(pedido => pedido.PontoVendaEntity.Id.Equals(pedidoDtoCreate.PontoVendaEntityId), true);

                PedidoEntity? p_s = pedidos_pdv.FirstOrDefault(p => p.Id.Equals(result.Id));

                return _mapper.Map<PedidoDto>(p_s);

            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<PedidoDto> EncerrarPedido(Guid pedidoId)
        {
            try
            {
                PedidoEntity? pedidoSelecionado = (await _pedidoRepository.SelectAsync(ped => ped.Id.Equals(pedidoId))).FirstOrDefault();
                if (pedidoSelecionado == null)
                    throw new ModelsExceptions($"Nenhum pedido encontrado com o guid: {pedidoId}");
                PedidoModels pedidoModel = _mapper.Map<PedidoModels>(pedidoSelecionado);
                pedidoModel.EncerrarPedidoModels();

                PedidoEntity result = await _repository.UpdateAsync(_mapper.Map<PedidoEntity>(pedidoModel));

                PedidoEntity? pedido = (await _pedidoRepository.SelectAsync(p => p.Id == result.Id, true)).SingleOrDefault();

                return _mapper.Map<PedidoDto>(pedido);
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PedidoDto> CancelarPedido(PedidoDtoCancelamento dtoCancelamento)
        {
            try
            {
                PedidoEntity pedidoSelecionado = await _repository.SelectAsync(dtoCancelamento.Id);
                if (pedidoSelecionado == null)
                    throw new ModelsExceptions($"Nenhum pedido encontrado com o guid: {dtoCancelamento.Id}");
                PedidoModels pedidoModel = _mapper.Map<PedidoModels>(pedidoSelecionado);

                pedidoModel.CancelarPedidoModels(dtoCancelamento.MotivoCancelamento);

                PedidoEntity result = await _repository.UpdateAsync(_mapper.Map<PedidoEntity>(pedidoModel));

                PedidoEntity? pedido = (await _pedidoRepository.SelectAsync(p => p.Id == result.Id, true)).SingleOrDefault();

                return _mapper.Map<PedidoDto>(pedido);
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public async Task<IEnumerable<PedidoDto>> Get(SituacaoPedidoEnum situacaoPedido)
        {
            try
            {
                IEnumerable<PedidoEntity> pedidosEntities = await _pedidoRepository.Get(situacaoPedido);
                return _mapper.Map<IEnumerable<PedidoDto>>(pedidosEntities);
                //return _mapper.Map<IEnumerable<PedidoDto>>(await _pedidoRepository.Get(situacaoPedido));
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PedidoDto> AtualizarValorPedido(Guid pedidoId)
        {
            try
            {

                //IEnumerable<PedidoEntity> inumerable = await _pedidoRepository.SelectAsync(pedido => pedido.Id.Equals(pedidoId), true);
                //PedidoEntity? pedido = inumerable.FirstOrDefault();
                //if (!pedido.SituacaoPedidoEnum.Equals(SituacaoPedidoEnum.Aberto))
                //    throw new ModelsExceptions("Pedido precisa estar aberto para ser atualizado");

                PedidoModels model = _mapper.Map<PedidoModels>(null);
                model.CalcularValorPedido();
                PedidoEntity entity = _mapper.Map<PedidoEntity>(model);

                PedidoEntity result = await _repository.UpdateAsync(entity);
                return _mapper.Map<PedidoDto>(result);

            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PedidoDto>> GetByIdPedido(Guid idPedido, bool fullConsulta)
        {
            try
            {
                IEnumerable<PedidoEntity> pedidoEntity = await _pedidoRepository.SelectAsync(pedido => pedido.Id.Equals(idPedido), true);

                return _mapper.Map<IEnumerable<PedidoDto>>(pedidoEntity);
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<PedidoDto>> Get(Guid idPdv)
        {
            try
            {
                IEnumerable<PedidoEntity> pedidoEntity = await _pedidoRepository.SelectAsync(pedido => pedido.PontoVendaEntity.Id.Equals(idPdv), true);

                return _mapper.Map<IEnumerable<PedidoDto>>(pedidoEntity);
            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PedidoDto> CancelarTodosItensPedidoReturnPedido(Guid idPedido)
        {
            try
            {
                PedidoEntity? pedido =
                    (await _pedidoRepository.SelectAsync(p => p.Id.Equals(idPedido), true)).SingleOrDefault();
                PedidoModels model = _mapper.Map<PedidoModels>(pedido);

                model.CancelarTodosItensPedido(null);

                PedidoEntity entity = _mapper.Map<PedidoEntity>(model);

                PedidoEntity result = await _repository.UpdateAsync(entity);

                PedidoDto resultPedidoValorAtualizado = await AtualizarValorPedido(result.Id);

                return resultPedidoValorAtualizado;

            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDto> RemoverAllItensPedido(Guid idPedido)
        {
            try
            {
                IEnumerable<ItemPedidoEntity> itens = await _itemPedidoRepository.SelectAsync(item => item.PedidoEntityId == idPedido);

                IEnumerable<Guid> ids = from item in itens
                                        select item.Id;

                int itens_deletados = await _repositoryItemPedidoEntity.DeleteAsync(ids);

                return await AtualizarValorPedido(idPedido);

            }
            catch (ModelsExceptions ex)
            {
                throw new ModelsExceptions(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
